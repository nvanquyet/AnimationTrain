using Assets.Scripts.AnimtionScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterMove _move;
        [SerializeField] private CharacterShoot _shoot;
        [SerializeField] private Rig_Weapon _rig;
        [SerializeField] private AnimationCtrl _anim;

        private void Awake()
        {
            Debug.Log("One player");
        }
        private void Start()
        {
            _move = GetComponent<CharacterMove>();
            _shoot = GetComponent<CharacterShoot>();
            _rig = GetComponentInChildren<Rig_Weapon>();
            Cursor.lockState = CursorLockMode.Locked;
        }
        public CharacterShoot GetCharacterShoot()
        {
            return _shoot;
        }

        public CharacterMove GetCharacterMove()
        {
            return _move;
        }
        public Rig_Weapon GetRigWeapon()
        {
            return _rig;
        }
        public AnimationCtrl GetAnimationCtrl()
        {
            return _anim;
        }
    }
}
