using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public interface IInput
    {
        Vector2 DirectionMove { get; }
        bool Run { get; }
        bool Jump { get; }
        bool Aim { get; }
        bool Shoot { get; }
    }

    public class InputCtrl : MonoBehaviour, IInput
    {
        public Vector2 DirectionMove => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        public bool Run => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        public bool Jump => Input.GetKeyUp(KeyCode.Space);

        public bool Aim => Input.GetKey(KeyCode.Mouse1);

        public bool Shoot => Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0);

    }

}
