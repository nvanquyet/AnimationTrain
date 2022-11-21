using UnityEngine.Animations.Rigging;
using UnityEngine;
using Assets.Scripts.Character;
using Assets.Scripts.CameraCtrl;
using Assets.Scripts.AnimtionScripts;

namespace Assets.Scripts.State
{
    public class AimState : StateControl
    {
        public override void EnterState(ControlState controlState, CameraAim _cameraAim)
        {
            _cameraAim.ChangeFOV(this);
        }

        public override void UpdateState(ControlState controlState)
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                controlState.SwitchState(controlState.idle);
            }
        }
    }
}
