using Assets.Scripts.Version2.State.StateLayer;
using UnityEngine;


namespace Assets.Scripts.Version2.GraphicsManagers.Animation
{
    public class AnimationLayer : MonoBehaviour, IAnimationLayer
    {
        [SerializeField] private Animator animator;
        [SerializeField] private int numberLayer;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        public void ControlLayer(StateLayer stateLayer,bool reload = false)
        {
            switch (stateLayer)
            {
                case StateLayer.NoWeapon:
                    {
                        SetWeightLayer(0, 1);
                        break;
                    }
                case StateLayer.HaveWeapon:
                    {
                        SetWeightLayer(1, 1);
                        break;
                    }
                case StateLayer.HaveWeaponS:
                    {
                        SetWeightLayer(2, 1);
                        animator.SetBool("Reload", false);
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
        public void SetWeightLayer(int index, float weight)
        {
            animator.SetLayerWeight(index,weight);
            for(int i = index + 1; i < numberLayer; i++)
            {
                animator.SetLayerWeight(i, 0);
            }
        }

        public void SetSmoothLayerWeight(int indexLayer, float value)
        {
            animator.SetLayerWeight(indexLayer, Mathf.Lerp(animator.GetLayerWeight(indexLayer), value, Time.fixedDeltaTime * 15f));
        }
    }
}
