using Assets.Scripts.Version3.State;
using Assets.Scripts.Version3.V3_Control;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Graphics
{
    public class ControlSpeedAnimation : MonoBehaviour
    {
        public void SetSpeedClip(Animator animator, string nameAnim, string parameter, float fireRate)
        {
            animator.SetFloat(parameter, GetAnimationClip(animator, nameAnim).length / fireRate);
        }
        public void ControlAnimtionSaR(PlayerAttack _playerAttack,Animator anim,TypeEquiq state)
        {
            switch (state)
            {
                case TypeEquiq.Gun:
                    {
                        if (_playerAttack.weapon != null)
                        {
                            SetSpeedClip(anim, "Firing Rifle", "ShootSpeed", _playerAttack.weapon._fireRate);
                            SetSpeedClip(anim, "Reloading", "ReloadTime", _playerAttack.weapon.timeReload);
                        }
                        break;
                    }
                case TypeEquiq.Melee:
                    {
                        if (_playerAttack.weapon != null)
                        {
                            SetSpeedClip(anim, "Attack", "ShootSpeed", _playerAttack.weapon._fireRate);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public AnimationClip GetAnimationClip(Animator animator, string name)
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

    }
}
