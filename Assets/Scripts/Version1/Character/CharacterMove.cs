using Assets.Scripts.AnimtionScripts;
using Assets.Scripts.InputControl;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterMove : MonoBehaviour
    {
        [Header("Animation Control")]
        [SerializeField] private AnimationCtrl _anim;
        [Header("Speed Move")]
        [SerializeField] private float speedR;
        [SerializeField] private float speedW;
        [SerializeField] private float speedC;
        private bool _isMove = false;
        private float speed;

        [Header("Objects and Transforms")]
        [SerializeField] private CharacterController controller;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _aimPos;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }
        private void Start()
        {
            speed = speedW;
        }

        public void Move(float horizontal,float vertical)
        {
            Vector3 direction = Vector3.zero;
            if (horizontal > 0)
            {
                direction += transform.right;
            }
            if (horizontal < 0)
            {
                direction -= transform.right;
            }
            if (vertical > 0)
            {
                direction += transform.forward;
            }
            if (vertical < 0)
            {
                direction -= transform.forward;
            }
            direction = direction.normalized;
            if (direction.magnitude >= 0.01f)
            {
                controller.Move(direction * speed * Time.fixedDeltaTime);
                _isMove = true;
            }
            else
            {
                direction = Vector3.zero;
                _isMove = false;
            }
            _anim.SetVelocity(horizontal, vertical);
        }
        public void Rotate(float horizontal, float vertical)
        {
            transform.Rotate(Vector3.up, Mathf.Atan2(horizontal, vertical));
        }
        public void SetSpeed(StateID codition)
        {
            switch (codition)
            {
                case StateID.Run:
                    {
                        this.speed = speedR;
                        break;
                    }
                case StateID.Crounch:
                    {
                        this.speed = speedC;
                        break;
                    }
                case StateID.Walk:
                    {
                        this.speed = speedW;
                        break;
                    }
            }
        }
        public bool IsMove()
        {
            return _isMove;
        }
    }
}