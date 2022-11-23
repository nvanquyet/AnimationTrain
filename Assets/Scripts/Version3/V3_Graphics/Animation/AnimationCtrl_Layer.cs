using UnityEngine;

namespace Assets.Scripts.Version3.V3_Graphics
{
    public interface IAnimationCtrl_Layer
    {
        public void SetWeightLayer(Animator animator, int index, float weight);
        public void SetSmoothLayerWeight(Animator animator, int indexLayer, float value);
    }
    public class AnimationCtrl_Layer : MonoBehaviour, IAnimationCtrl_Layer
    {
        public void SetWeightLayer(Animator animator, int index, float weight)
        {
            animator.SetLayerWeight(index, weight);
            for (int i = index + 1; i < animator.layerCount; i++)
            {
                animator.SetLayerWeight(i, 0);
            }
        }


        public void SetSmoothLayerWeight(Animator animator, int indexLayer, float value)
        {
            animator.SetLayerWeight(indexLayer, Mathf.Lerp(animator.GetLayerWeight(indexLayer), value, Time.fixedDeltaTime * 15f));
            for (int i = indexLayer + 1; i < animator.layerCount; i++)
            {
                animator.SetLayerWeight(i, 0);
            }
        }

    }
}
