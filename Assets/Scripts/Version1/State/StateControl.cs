using Assets.Scripts.AnimtionScripts;
using Assets.Scripts.CameraCtrl;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.State
{
    public abstract class StateControl
    {
        public abstract void UpdateState(ControlState control);
        public abstract void EnterState(ControlState control, CameraAim _cameraAim);
    }
}