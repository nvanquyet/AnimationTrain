using UnityEngine;

namespace Assets.Scripts.Version3.V3_Input
{
    public interface IInput
    {
        Vector2 DirectionMove { get; }
        bool Run { get; }
        bool Jump { get; }
        bool Aim { get; }
        bool Shoot { get; }
        bool Crounch { get; }
        bool Reload { get; }
        bool ActiveWeapon { get; }
        float ChangeWeaponByMouse { get; }
        public bool ChangeWeaponByKeyCode(KeyCode key);
    }

    public class InputCtrl : MonoBehaviour, IInput
    {
        public Vector2 DirectionMove => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        public bool Run => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        public bool Jump => Input.GetKeyUp(KeyCode.Space);

        public bool Aim => Input.GetKey(KeyCode.Mouse1);
        public bool Crounch => Input.GetKeyDown(KeyCode.C);

        public bool Shoot => Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0);

        public bool Reload => Input.GetKeyUp(KeyCode.R);

        public bool ActiveWeapon => Input.GetKeyUp(KeyCode.X);

        public float ChangeWeaponByMouse => Input.GetAxis("Mouse ScrollWheel");

        public bool ChangeWeaponByKeyCode(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }
    }

}
