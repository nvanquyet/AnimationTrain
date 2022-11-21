/*using UnityEngine;
using Assets.Scripts.InputManager;
using Assets.Scripts.ControlManager.Move;
using Assets.Scripts.ControlManager.Attack;
using Assets.Scripts.GraphicsManagers.Animation;

namespace Assets.Scripts._GameWorld
{
    public class GameWorld : MonoBehaviour
    {
        [SerializeField] private InputCtrl _input;
        [SerializeField] private MovePlayer _playerMove;
        [SerializeField] private PlayerAttack _playerShoot;
        private void Awake()
        {
            _input = GetComponentInChildren<InputCtrl>();
            _playerMove = GetComponentInChildren<MovePlayer>();
            _playerShoot = GetComponentInChildren<PlayerAttack>();
        }
        private void FixedUpdate()
        {
            MoveControl();
            JumpControl();
            RunControl();
            WeaponActive();
            AttackControl();
        }


        void MoveControl()
        {
            _playerMove.Move(_input.DirectionMove());
        }


        void JumpControl()
        {
            if (_input.Jump())
            {
                _playerMove.Jump();
            }
        }

        void RunControl()
        {
            if (_input.Run())
            {
                _playerMove.SetState(StateID.Run);
            }
            else
            {
                _playerMove.SetState(StateID.Walk);
            }
        }
        void AttackControl()
        {
            if (_input.Attack() && _input.HoldWeapon())
            {
                _playerShoot.Attack();
            }
        }

        void WeaponActive()
        {
            _playerShoot.ActiveGun(_input.HoldWeapon());
        }

    }
}
*/