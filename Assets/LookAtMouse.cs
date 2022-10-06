using UnityEngine;

namespace Assets
{
    public class LookAtMouse : MonoBehaviour
    {           
        [SerializeField] private Camera _camera;

        private void Update()
        {
            LookMouse();
        }


        void LookMouse()
        {
            float rotateX = Input.GetAxis("Mouse X");
            //float rotateY = Input.GetAxis("Mouse Y");
            transform.Rotate(0, rotateX, 0); 
        }

    }
}
