using Assets.Scripts.State;
using Assets.Scripts.Version2.State.State;
using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.CameraCtrl
{
    public class CameraAimVer2 : MonoBehaviour
    {
        [SerializeField] private float _aimFOV;
        [SerializeField] private float _noAimFOV;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private void Awake()
        {
            _virtualCamera = GetComponentInParent<CinemachineVirtualCamera>();
        }

        public void ChangeFOV(StateProperties state)
        {
            if (state.Equals(StateProperties.Aim))
            {
                _virtualCamera.m_Lens.FieldOfView = _aimFOV;
            }
            if (state.Equals(StateProperties.NoAim))
            {
                _virtualCamera.m_Lens.FieldOfView = _noAimFOV;
            }
        }
    }

}
