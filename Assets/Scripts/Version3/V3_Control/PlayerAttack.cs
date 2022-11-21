using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Version3.State.State;
using Assets.Scripts.Version3.State.StateLayer;
using Assets.Scripts.Version3.V3_Input;
using Assets.Scripts.Version3.V3_Weapon;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Control
{
    public interface IPlayerAttack
    {
        public void Attack();
        StateLayer GetState { get; }
        bool isReload { get; }
        StateProperties ChangeWeapon { get; }
    }

    public class PlayerAttack : MyBehaviour, IPlayerAttack
    {
        [Header("Input")]
        [SerializeField] private InputCtrl _inputCtrl;
        [SerializeField] private StateLayer m_state;
        [SerializeField] private StateProperties changeWeapon;

        [Header("Weapon")]
        [SerializeField] public PlayerControlWeapon weaponCtrl;
        public Weapon weapon;

        private bool reload;
        private bool haveWeapon = false;

        private void Awake()
        {
            _inputCtrl = GetComponentInChildren<InputCtrl>();
            weaponCtrl = GetComponentInChildren<PlayerControlWeapon>();
        }

        public override void LoadComponent()
        {
            weapon = weaponCtrl.GetWeapon().GetComponent<Weapon>();
        }
        public StateLayer GetState => m_state;
        public bool isReload => reload;


        public StateProperties ChangeWeapon => changeWeapon;

        private void Update()
        {
            if (haveWeapon)
            {
                if (weaponCtrl.WeponControl())
                {
                    weapon = weaponCtrl.GetWeapon().GetComponent<Weapon>();
                    changeWeapon = StateProperties.ChangeWeapon;
                }
                else
                {
                    changeWeapon = StateProperties.NoChangeWeapon;
                }
            }
            if (_inputCtrl.ActiveWeapon)
            {
                HandleWeapon();
            }
            if (weaponCtrl.GetState().Equals(StateProperties.Shoot))
            {
                if (_inputCtrl.Reload)
                {
                    Reload();
                }
            }
                if (!reload)
                {
                    if (_inputCtrl.Shoot)
                    {
                        Attack();
                    }
                    else
                    {
                        if (haveWeapon)
                        {
                            m_state = StateLayer.HaveWeapon;
                        }
                        else
                        {
                            m_state = StateLayer.NoWeapon;
                        }
                    }
                }
            
        }

        void HandleWeapon()
        {
            haveWeapon = !haveWeapon;
        }

        void Reload()
        {
            if(haveWeapon && !reload)
            {
                reload = true;
                m_state = StateLayer.HaveWeaponR;
                Debug.Log("Reload");
                StartCoroutine(ReloadComplete(weapon.timeReload));
            }
        }

        IEnumerator ReloadComplete(float timeReload)
        {
            yield return new WaitForSeconds(timeReload);
            Debug.Log("Reload Complete");
            m_state = StateLayer.HaveWeapon;
            reload = false;
            weapon.Recharge();
        }
        public void Attack()
        {
            if (!reload && haveWeapon)
            {
                m_state = StateLayer.HaveWeaponS;
                if (weapon.Attack())
                {
                    Debug.Log("Attack Logic");
                }
            }
        }

    }
}
