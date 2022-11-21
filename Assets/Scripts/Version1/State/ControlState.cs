using UnityEngine;
using Assets.Scripts.CameraCtrl;
using Assets.Scripts.AnimtionScripts;

namespace Assets.Scripts.State
{
    public class ControlState : MonoBehaviour
    {
        [Header("State Properties")]
        [SerializeField] private StateControl currentState;
        [HideInInspector] public AimState aim = new AimState();
        [HideInInspector] public IdleState idle = new IdleState();
        [Header("Camera")]
        [SerializeField] private CameraAim _cameraAim;
        [Header("Animation Control")]
        [SerializeField] private AnimationCtrl _animator;
        private void Start()
        {
            SwitchState(this.idle);
        }

        public void SwitchState(StateControl state)
        {
            currentState = state;
            currentState.EnterState(this, _cameraAim);
        }
        public StateControl GetCurrentState()
        {
            return this.currentState;
        }
    }
}
