using System.Collections;
using Assets.Scripts.Version3.State;
using Assets.Scripts.Version3.V3_Input;
using Assets.Scripts.Version3.V3_Weapon;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Control
{
    public class PlayerAttack : MyBehaviour
    {
        [Header("Input")]
        [SerializeField] private InputCtrl _inputCtrl;
        [Header("Weapon")]
        [SerializeField] public PlayerControlWeapon weaponCtrl;
        public TypeAttack typeAttack { get; set; }

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
        public bool isReload => reload;

        private void Update()
        {
            if (haveWeapon)
            {
                if (weaponCtrl.WeponControl())
                {
                    weapon = weaponCtrl.GetWeapon().GetComponent<Weapon>();
                }
            }
            if (_inputCtrl.ActiveWeapon)
            {
                HandleWeapon();
            }
            if (weaponCtrl.typeEquiq.Equals(TypeEquiq.Gun))
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
                    switch (weaponCtrl.typeEquiq) 
                    {
                        case TypeEquiq.Gun:
                            {
                                typeAttack = TypeAttack.GunAttack;
                                break;
                            }
                        case TypeEquiq.Melee:
                            {
                                typeAttack = TypeAttack.MeleeAttack;
                                break;
                            }
                    }
                    Attack();
                }
                else
                {
                    typeAttack = TypeAttack.NoAttack;
                    if (!haveWeapon)
                    {
                        weaponCtrl.typeEquiq = TypeEquiq.NoWeapon;
                    }
                    else
                    {
                        if(weaponCtrl.GetSelectedWeapon() != 2)
                        {
                            weaponCtrl.typeEquiq = TypeEquiq.Gun;
                        }
                        else
                        {
                            weaponCtrl.typeEquiq = TypeEquiq.Melee;
                        }
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
                typeAttack = TypeAttack.Recharge;
                Debug.Log("Reload");
                StartCoroutine(ReloadComplete(weapon.timeReload));
            }
        }

        IEnumerator ReloadComplete(float timeReload)
        {
            yield return new WaitForSeconds(timeReload);
            Debug.Log("Reload Complete");
            typeAttack = TypeAttack.NoAttack;
            reload = false;
            weapon.Recharge();
        }
        public void Attack()
        {
            if (!reload && haveWeapon)
            {
                if (weapon.Attack())
                {
                    Debug.Log("Attack Logic");
                }
            }
        }

    }
}
