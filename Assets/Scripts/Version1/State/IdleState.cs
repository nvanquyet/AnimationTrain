using Assets.Scripts.AnimtionScripts;
using Assets.Scripts.CameraCtrl;
using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Assets.Scripts.State
{
    public class IdleState : StateControl
    {
        public override void EnterState(ControlState controlState,CameraAim _cameraAim)
        {
            _cameraAim.ChangeFOV(this);
        }

        public override void UpdateState(ControlState controlState)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                controlState.SwitchState(controlState.aim);
            }
        }
    }


}

