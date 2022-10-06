using UnityEngine;

namespace Assets
{
    public class LookAtMouse : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private float mouseSpeed = 3f;

        private void Update()
        {
            LookMouse();
        }


        void LookMouse()
        {
            float rotateX = Input.GetAxis("Mouse X") * mouseSpeed;
            float rotateY = Input.GetAxis("Mouse Y") * mouseSpeed;

            transform.Rotate(0, rotateX, 0); 

        }

    }
}
