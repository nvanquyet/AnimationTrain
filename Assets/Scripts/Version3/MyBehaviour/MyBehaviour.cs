using UnityEngine;

    public abstract class MyBehaviour : MonoBehaviour
    {
        private void Start()
        {
            LoadComponent();
        }

        private void Reset()
        {
            LoadComponent();
        }

        public abstract void LoadComponent();
    }
