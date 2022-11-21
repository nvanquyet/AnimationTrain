using Assets.Scripts.State;
using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.CameraCtrl
{
    public class CameraAim : MonoBehaviour
    {
        [SerializeField] private float _aimFOV;
        [SerializeField] private float _noAimFOV;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        public void ChangeFOV(StateControl state)
        {
            if (state.GetType().Equals(typeof(AimState)))
            {
                _virtualCamera.m_Lens.FieldOfView = _aimFOV;
            }
            if (state.GetType().Equals(typeof(IdleState)))
            {
                _virtualCamera.m_Lens.FieldOfView = _noAimFOV;
            }
        }
    }

}
