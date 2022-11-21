using Assets.Scripts.Version3.State.StateMove;
using Assets.Scripts.Version3.V3_Control;
using UnityEngine;


namespace Assets.Scripts.Version3.V3_Graphics
{
    public interface IAnimationMove
    {
        public void SetProperties(Vector2 direction);
        public void ChangeAnimation(StateMove state);
    }
    public class AnimationMove : MyBehaviour, IAnimationMove
    {
        [SerializeField] private MovePlayer _player;
        [SerializeField] private Animator animator;

        [SerializeField] private Transform followPos;
        [SerializeField] private Vector3 standPosCam;
        [SerializeField] private Vector3 crounchPosCam;
        [SerializeField] private float distance;

        //Animation
        private const string MOVE = "Move";
        private const string RUN = "Run";
        private const string CROUNCH = "Crounch";
        private const string Jump = "Jump";

        private void Awake()
        {
            animator = GetComponent<Animator>();
            _player = GetComponentInParent<MovePlayer>();
           
        }

        public override void LoadComponent()
        {
            followPos = transform.parent.Find("Follow Position");
            distance = -0.25f;
            standPosCam = followPos.localPosition;
            crounchPosCam = standPosCam + new Vector3(0, distance, 0);
        }

        private void Update()
        {
            SetProperties(_player.GetPropertiesMove);
            ChangeAnimation(_player.GetState);
        }

        public void ChangeAnimation(StateMove state)
        {
            switch (state)
            {
                case StateMove.Walk:
                    {
                        followPos.localPosition = standPosCam;
                        animator.SetBool(CROUNCH, false);
                        animator.SetBool(RUN, false);
                        break;
                    }
                case StateMove.Run:
                    {
                        followPos.localPosition = standPosCam;
                        animator.SetBool(CROUNCH, false);
                        animator.SetBool(RUN, true);
                        break;
                    }
                case StateMove.Crounch:
                    {
                        followPos.localPosition = crounchPosCam;
                        animator.SetBool(CROUNCH, true);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public void SetProperties(Vector2 direction)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }

    }
}
