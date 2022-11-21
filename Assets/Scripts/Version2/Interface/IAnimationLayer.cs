using Assets.Scripts.Version2.State.StateLayer;
using UnityEngine;

namespace Assets.Scripts.Version2.GraphicsManagers.Animation
{
    public interface IAnimationLayer
    {
        public void ControlLayer(StateLayer stateLayer,bool reload);
        public void SetWeightLayer(int index, float weight);
    }
}
