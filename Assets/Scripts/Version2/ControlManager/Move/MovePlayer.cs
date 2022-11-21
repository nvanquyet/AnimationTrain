using Assets.Scripts.Version2.State.StateMove;
using UnityEngine;

namespace Assets.Scripts.ControlManager.Move
{
    public interface IPlayerMove
    {
        public void Move(Vector2 dirrection);
        public void Jump();
        public void Rotate(Vector2 dirrection);
        public void ControlState(StateMove state);
    }

    public class MovePlayer : MonoBehaviour, IPlayerMove
    {
        [SerializeField] private Rigidbody _control;
        [Header("Properties")]
        [SerializeField] private float m_jumpForce;
        [SerializeField] private float speedR;
        [SerializeField] private float speedW;
        [SerializeField] private float speedC;
        private float m_speed;

        private void Awake()
        {
            _control = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            m_jumpForce = 750;
            speedW = 2.5f;
            speedR = 5f;
            speedC = 2f;
            m_speed = speedW;
        }
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
            //_control.MovePosition() = Vector3.Lerp(transform.position, transform.position + m_direction * m_speed, Time.fixedDeltaTime * smooth);
        }
        public void Rotate(Vector2 dirrection)
        {
            this.transform.Rotate(Vector3.up, Mathf.Atan2(dirrection.x, dirrection.y));
        }
        public void ControlState(StateMove state)
        {
            switch (state)
            {
                case StateMove.Walk:
                    {
                        m_speed = speedW;
                        break;
                    }
                case StateMove.Crounch:
                    {
                        m_speed = speedC;
                        break;
                    }
                case StateMove.Run:
                    {
                        m_speed = speedR;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        
    }

}
