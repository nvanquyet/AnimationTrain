using Assets.Scripts.Version3.State;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Graphics
{
    public interface IAnimationCtrl_Anim
    {
        public void PlayAnim(Animator animator, TypeAttack type);
    }
    public class AnimationCtrl_Anim : MonoBehaviour, IAnimationCtrl_Anim
    {
        private const string GunAttack = "GunAttack";
        private const string MeleeAttack = "MelleAttack";
        private const string ReCharge = "Reloading";


        public void PlayAnim(Animator animator,TypeAttack type)
        {
            switch (type)
            {
                case TypeAttack.GunAttack:
                    {
                        animator.Play(GunAttack);
                        break;
                    }
                case TypeAttack.MeleeAttack:
                    {
                        animator.Play(MeleeAttack);
                        break;
                    }
                case TypeAttack.Recharge:
                    {
                        animator.Play(ReCharge);
                        break;
                    }
            }
        }
    }
}
