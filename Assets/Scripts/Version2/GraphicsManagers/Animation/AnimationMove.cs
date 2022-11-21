using Assets.Scripts.Version2.State.StateMove;
using UnityEngine;

namespace Assets.Scripts.GraphicsManagers.Animation
{
    public class AnimationMove : MonoBehaviour, IAniamtionMove
    {
        [SerializeField] private Animator animator;
        [SerializeField] private int _numberLayer;

        [SerializeField] private Transform followPos;
        [SerializeField] private Vector3 standPosCam;
        [SerializeField] private Vector3 crounchPosCam;
        [SerializeField] private float distance;

        //Parameters bool animator
        private const string RUN = "Run";
        private const string CROUNCH = "Crounch";

        private void Awake()
        {
            animator = GetComponent<Animator>();
            followPos = transform.parent.Find("Follow Position");
        }

        private void Start()
        {
            standPosCam = followPos.localPosition;
            crounchPosCam = standPosCam + new Vector3(0, distance, 0);
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
        public void SetProperties(float horizontal, float vertical)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
        }
    }
}
