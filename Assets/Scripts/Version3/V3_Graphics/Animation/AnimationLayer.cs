using Assets.Scripts.Version3.State;
using Assets.Scripts.Version3.V3_Control;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Graphics
{
    public class AnimationLayer : MyBehaviour
    {
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private Animator animator;
        [SerializeField] private ShootingEffect effect;
        [SerializeField] private ControlSpeedAnimation speedCtrl;
        [SerializeField] private AnimationCtrl_Layer animLayer;

        private void Awake()
        {
            _playerAttack = GetComponentInParent<PlayerAttack>();
            animator = GetComponent<Animator>();
            speedCtrl = GetComponent<ControlSpeedAnimation>();
            animLayer = GetComponent<AnimationCtrl_Layer>();
        }
        public override void LoadComponent()
        {
            ChangeWeapon();
        }

        private void Update()
        {
            ChangeWeapon();
            switch (_playerAttack.weaponCtrl.typeEquiq)
            {
                case TypeEquiq.Melee:
                    {
                        break;
                    }
                case TypeEquiq.Gun:
                    {
                        ControlLayerS(_playerAttack.typeAttack);
                        break;
                    }
                default:
                    {
                        animLayer.SetSmoothLayerWeight(animator, 0, 1);
                        break;
                    }
            }

        }
        public void ControlLayerM(TypeAttack state)
        {
            switch (state)
            {
                case TypeAttack.NoAttack:
                    {
                        animLayer.SetSmoothLayerWeight(animator, 1, 1);
                        break;
                    }
                case TypeAttack.MeleeAttack:
                    {
                        animLayer.SetSmoothLayerWeight(animator, 2, 1);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public void ControlLayerS(TypeAttack state)
        {
            switch (state)
            {
                case TypeAttack.NoAttack:
                    {
                        animLayer.SetSmoothLayerWeight(animator, 1, 1);
                        break;
                    }
                case TypeAttack.GunAttack:
                    {
                        animLayer.SetSmoothLayerWeight(animator, 2, 1);
                        break;
                    }
                case TypeAttack.Recharge:
                    {
                        animLayer.SetSmoothLayerWeight(animator, 2, 1);
                        animator.SetBool("Reload", true);
                        break;
                    }
            }
        }


        public void ChangeWeapon()
        {
            switch (_playerAttack.weaponCtrl.typeChange)
            {
                case TypeChange.ChangeGun1:
                    {
                        MeleeAttack();
                        break;
                    }
                case TypeChange.ChangeGun2:
                    {
                        ShootAttack();
                        break;
                    }
                case TypeChange.ChangeMelee:
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
        
        void MeleeAttack()
        {
            speedCtrl.ControlAnimtionSaR(_playerAttack, animator, _playerAttack.weaponCtrl.typeEquiq);
        }
        void ShootAttack()
        {
            effect = _playerAttack.weaponCtrl.GetWeapon().GetComponentInChildren<ShootingEffect>();
            speedCtrl.ControlAnimtionSaR(_playerAttack, animator, _playerAttack.weaponCtrl.typeEquiq);
        }
    }
}
