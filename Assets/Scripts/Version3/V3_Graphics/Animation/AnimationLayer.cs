using Assets.Scripts.Version3.State.State;
using Assets.Scripts.Version3.State.StateLayer;
using Assets.Scripts.Version3.V3_Control;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Graphics
{
    public interface IAnimationLayer
    {
        public void ControlLayerS(StateLayer stateLayer);
        public void ControlLayerM(StateLayer stateLayer);
        public void SetWeightLayer(int index, float weight);
        public void SetSmoothLayerWeight(int indexLayer, float value);
        public void SetSpeedClip(string nameAnim,string parameter, float fireRate);
    }
    public class AnimationLayer : MyBehaviour, IAnimationLayer
    {
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private Animator animator;
        [SerializeField] private ShootingEffect effect;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            _playerAttack = GetComponentInParent<PlayerAttack>();
        }
        public override void LoadComponent()
        {
            ChangeWeapon();
        }

        private void Update()
        {
            if(_playerAttack.ChangeWeapon.Equals(StateProperties.ChangeWeapon))
            {
                ChangeWeapon();
            }
            switch (_playerAttack.weaponCtrl.GetState())
            {
                case StateProperties.Melee:
                    {
                        ControlLayerM(_playerAttack.GetState);
                        break;
                    }
                case StateProperties.Shoot:
                    {
                        ControlLayerS(_playerAttack.GetState);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
        public void ControlLayerS(StateLayer stateLayer)
        {
            switch (stateLayer)
            {
                case StateLayer.NoWeapon:
                    {
                        SetSmoothLayerWeight(0, 1);
                        break;
                    }
                case StateLayer.HaveWeapon:
                    {
                        SetSmoothLayerWeight(1, 1);
                        break;
                    }
                case StateLayer.HaveWeaponS:
                    {
                        SetSmoothLayerWeight(2, 1);
                        animator.SetBool("Reload", false);
                        effect.PlayFX("Shoot");
                        break;
                    }
                case StateLayer.HaveWeaponR:
                    {
                        SetWeightLayer(2, 1);
                        animator.SetBool("Reload", true);
                        break;
                    }
            }
        }
        public void ControlLayerM(StateLayer stateLayer)
        {
            switch (stateLayer)
            {
                case StateLayer.NoWeapon:
                    {
                        SetSmoothLayerWeight(0, 1);
                        break;
                    }
                case StateLayer.HaveWeapon:
                    {
                        SetSmoothLayerWeight(1, 1);
                        break;
                    }
                case StateLayer.HaveWeaponS:
                    {
                        Debug.Log("Attack Animation");
                        animator.SetBool("Attack",true);
                        StartCoroutine(AttackComplete(_playerAttack.weapon._fireRate));
                        break;
                    }
            }
        }

        IEnumerator AttackComplete(float time)
        {
            yield return new WaitForSeconds(time);
            animator.SetBool("Attack", false);
        }
        public void SetWeightLayer(int index, float weight)
        {
            animator.SetLayerWeight(index,weight);
            for(int i = index + 1; i < animator.layerCount; i++)
            {
                animator.SetLayerWeight(i, 0);
            }
        }

        public void SetSmoothLayerWeight(int indexLayer, float value)
        {
            animator.SetLayerWeight(indexLayer, Mathf.Lerp(animator.GetLayerWeight(indexLayer), value, Time.fixedDeltaTime * 15f));
            for (int i = indexLayer + 1; i < animator.layerCount; i++)
            {
                animator.SetLayerWeight(i, 0);
            }
        }

        public void SetSpeedClip(string nameAnim, string parameter, float fireRate)
        {
            animator.SetFloat(parameter, GetAnimationClip(nameAnim).length / fireRate);
        }
        public void ControlAnimtionSaR(StateProperties state)
        {
            switch (state)
            {
                case StateProperties.Shoot:
                    {
                        if (_playerAttack.weapon != null)
                        {
                            SetSpeedClip("Firing Rifle", "ShootSpeed", _playerAttack.weapon._fireRate);
                            SetSpeedClip("Reloading", "ReloadTime", _playerAttack.weapon.timeReload);
                        }
                        break;
                    }
                case StateProperties.Melee:
                    {
                        if (_playerAttack.weapon != null)
                        {
                            SetSpeedClip("Attack", "ShootSpeed", _playerAttack.weapon._fireRate);
                        }
                        break;
                    }
            }
            
        }

        public AnimationClip GetAnimationClip(string name)
        {
            if (!animator) 
            {
                Debug.Log("no animator");
                return null; // no animator
            }
            
            foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name.Equals(name))
                {
                    return clip;
                }
            }
            Debug.Log("no animation");
            return null; // no clip by that name
        }

        public void ChangeWeapon()
        {
            switch (_playerAttack.weaponCtrl.GetState())
            {
                case StateProperties.Melee:
                    {
                        MeleeAttack();
                        break;
                    }
                case StateProperties.Shoot:
                    {
                        ShootAttack();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        
        public void ChangeAnimtor(string nameCtrl)
        {
            animator.runtimeAnimatorController = Resources.Load("Animator/PlayerAnimCtr_" + nameCtrl) as RuntimeAnimatorController;
        }


        void MeleeAttack()
        {
            ChangeAnimtor("Melee");
            ControlAnimtionSaR(_playerAttack.weaponCtrl.GetState());
        }
        void ShootAttack()
        {
            ChangeAnimtor("Shoot");
            effect = _playerAttack.weaponCtrl.GetWeapon().GetComponentInChildren<ShootingEffect>();
            ControlAnimtionSaR(_playerAttack.weaponCtrl.GetState());
        }
    }
}
