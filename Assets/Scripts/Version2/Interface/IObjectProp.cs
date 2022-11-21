
using UnityEngine;
using Assets.Scripts.Version2.State.StateLayer;

namespace Assets.Scripts.Version2.GraphicsManagers.Graphics
{
    public interface IObjectProp
    {
        public void ActiveObject(StateLayer stateLayer,bool isReload);
        public void SmoothWeight(float weight);
        public void SetOffset(Vector3 offset);
    }
}
