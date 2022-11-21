using Assets.Scripts.AnimtionScripts;
using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Assets.Scripts.InputControl
{
    public class InputController : MonoBehaviour
    {
        //[SerializeField] private CharacterMove moveController;
        [SerializeField] private PlayerController _player;
        [SerializeField] private float _timeReload;
        private AnimationCtrl animtor;
        public float horizontal;
        public float vertical;

        private void Start()
        {
            if(_player != null)
            {
                animtor = _player.GetAnimationCtrl();
            }
        }
        void Update()
        {
            if(animtor == null)
            { 
                return;
            }
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            _player.GetCharacterMove().Move(horizontal, vertical);
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                animtor.SetRun(true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animtor.SetRun(false);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                animtor.SetSprint();
                if (animtor.GetSprint())
                {
                    _player.GetRigWeapon().GetRHand().GetComponent<MultiAimConstraint>().weight = 1;
                }
                else
                {
                    _player.GetRigWeapon().GetRHand().GetComponent<MultiAimConstraint>().weight = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                animtor.SetCrounch();
            }
            if (Input.GetKeyDown(KeyCode.R) && animtor.GetSprint() && !animtor.GetReload())
            {
                _player.GetCharacterShoot().Reloading(_timeReload);
            }
            animtor.GetState().GetCurrentState().UpdateState(animtor.GetState());
            animtor.Sprint();
        }
    }
}
