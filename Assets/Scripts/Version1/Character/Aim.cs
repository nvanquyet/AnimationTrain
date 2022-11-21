using UnityEngine;

namespace Assets.Scripts.Character
{
    public class Aim : MonoBehaviour
    {
        public Transform _aimpos;
        public float smooth;
        public LayerMask aimMask;

        private void Update()
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
            {
                _aimpos.position = Vector3.Lerp(_aimpos.position, hit.point, smooth * Time.deltaTime);
            }
            
        }
    }
}