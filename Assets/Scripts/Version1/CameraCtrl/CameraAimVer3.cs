using Assets.Scripts.State;
using Assets.Scripts.Version2.State.State;
using Assets.Scripts.Version3.V3_Input;
using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.CameraCtrl
{
    public class CameraAimVer3 : MonoBehaviour
    {
        [SerializeField] private float _aimFOV;
        [SerializeField] private InputCtrl _input;
        [SerializeField] private float _noAimFOV;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private void Awake()
        {
            _virtualCamera = GetComponentInParent<CinemachineVirtualCamera>();
        }
        private void Update()
        {
            if (_input.Aim)
            {
                ChangeFOV(_aimFOV);
            }
            else
            {
                ChangeFOV(_noAimFOV);
            }
        }

        public void ChangeFOV(float _fov)
        {
            _virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_virtualCamera.m_Lens.FieldOfView, _fov, Time.deltaTime * 10);
        }
    }

}
