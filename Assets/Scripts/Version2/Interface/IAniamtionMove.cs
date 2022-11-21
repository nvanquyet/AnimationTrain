using Assets.Scripts.Version2.State.StateMove;
using UnityEngine;

namespace Assets.Scripts.GraphicsManagers.Animation
{
    public interface IAniamtionMove
    {
        public void ChangeAnimation(StateMove state);
        public void SetProperties(float horizontal, float vertical);
    }
}
