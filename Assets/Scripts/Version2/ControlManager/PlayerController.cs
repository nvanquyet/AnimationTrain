/*using Assets.Scripts.ControlManager.Attack;
using Assets.Scripts.ControlManager.Move;
using Assets.Scripts.InputManager;
using UnityEngine;

namespace Assets.Scripts.ControlManager
{
    public class PlayerController : MonoBehaviour,IPLayerController
    {
        [SerializeField] private InputCtrl _inputManager;
        [SerializeField] private MovePlayer _playerMove;
        [SerializeField] private PlayerAttack _playerShoot;

        private void Awake()
        {
            _inputManager = GetComponentInChildren<InputCtrl>();
            _playerMove = GetComponentInChildren<MovePlayer>();
            _playerShoot = GetComponentInChildren<PlayerAttack>();
        }

        InputCtrl IPLayerController.GetInput => _inputManager;

        MovePlayer IPLayerController.GetMove => _playerMove;

        PlayerAttack IPLayerController.GetPlayerAttack => _playerShoot;

    }

    public interface IPLayerController
    {
        InputCtrl GetInput { get; }
        MovePlayer GetMove { get; }
        PlayerAttack GetPlayerAttack { get; }
    }
}
*/