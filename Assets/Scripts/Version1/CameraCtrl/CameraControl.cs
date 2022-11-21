using UnityEngine;

namespace Assets.Scripts.CameraCtrl
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _followPosition;
        [SerializeField] private Cinemachine.AxisState _xAxis;
        [SerializeField] private Cinemachine.AxisState _yAxis;

        // Update is called once per frame
        void Update()
        {
            _xAxis.Update(Time.deltaTime);
            _yAxis.Update(Time.deltaTime);
            _followPosition.localEulerAngles = new Vector3(_yAxis.Value, _followPosition.localEulerAngles.y, _followPosition.localEulerAngles.z);
            _target.eulerAngles = new Vector3(_target.eulerAngles.x, _xAxis.Value, _target.eulerAngles.z);
        }
    }

}
