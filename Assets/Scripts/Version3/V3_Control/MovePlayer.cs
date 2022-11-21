using Assets.Scripts.Version3.State.StateMove;
using Assets.Scripts.Version3.V3_Input;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Control
{
    public interface IPlayerMove
    {
        Vector2 GetPropertiesMove{ get; }
        StateMove GetState { get; }
        public void Move(Vector2 dirrection);
        public void Jump();
        public void Rotate(Vector2 dirrection);
        public void ControlState();
    }

    public class MovePlayer : MyBehaviour, IPlayerMove
    {
        [SerializeField] private InputCtrl _input;
        [SerializeField] private Rigidbody _control;
        [SerializeField] private StateMove m_state;
        [SerializeField] private bool crouch;
        [Header("Properties")]
        [SerializeField] private float m_jumpForce;
        [SerializeField] private float speedR;
        [SerializeField] private float speedW;
        [SerializeField] private float speedC;
        private float m_speed;

        private void Awake()
        {
            _input = GetComponentInChildren<InputCtrl>();
            _control = GetComponent<Rigidbody>();
        }

        public override void LoadComponent()
        {
            m_jumpForce = 100;
            speedR = 5;
            speedC = 2.5f;
            speedW = 3.5f;
        }

        private void Update()
        {
            ControlState();
            Move(_input.DirectionMove);
        }
        private void Start()
        {
            m_jumpForce = 750;
            speedW = 2.5f;
            speedR = 5f;
            speedC = 2f;
            m_speed = speedW;
        }

        public Vector2 GetPropertiesMove => _input.DirectionMove;

        public void Jump()
        {
            if(Mathf.Abs(_control.velocity.y) < 0.1f)
            {
                _control.AddForce(Vector3.up * m_jumpForce);
            }
        }
        public void Move(Vector2 dirrection)
        {
            Vector3 m_direction = Vector3.zero;
            if (dirrection.x > 0)
            {
                m_direction += transform.right;
            }
            if (dirrection.x < 0)
            {
                m_direction -= transform.right;
            }
            if (dirrection.y > 0)
            {
                m_direction += transform.forward;
            }
            if (dirrection.y < 0)
            {
                m_direction -= transform.forward;
            }
            _control.MovePosition(this.transform.position + m_direction * Time.fixedDeltaTime * m_speed);
        }
        public void Rotate(Vector2 dirrection)
        {
            this.transform.Rotate(Vector3.up, Mathf.Atan2(dirrection.x, dirrection.y));
        }
        public void ControlState()
        {
            if (_input.Jump)
            {
                m_state = StateMove.Jump;
            }
            else
            {
                if(_input.Crounch)
                {
                    crouch = !crouch;
                }
                if (crouch)
                {
                    m_state = StateMove.Crounch;
                    m_speed = speedC;
                }
                else
                {
                    if (_input.Run)
                    {
                        m_state = StateMove.Run;
                        m_speed = speedR;
                    }
                    else
                    {
                        m_state = StateMove.Walk;
                        m_speed = speedW;
                    }
                }

            }
        }


        public StateMove GetState => m_state;
    }

}
