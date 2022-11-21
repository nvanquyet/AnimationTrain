using Assets.Scripts.BulletScripts;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Weapon
{
    public class GunWeapon : Weapon
    {
        [SerializeField] private AmmoBullet _amBullet;
        [SerializeField] private Transform _posShoot;
        [SerializeField] private Transform _posAim;

        private void Awake()
        {
            _amBullet = GetComponent<AmmoBullet>();
        }
        public override bool Attack()
        {
            if (ReadyToAttack())
            {
                if(_amBullet.GetCurrentAmmo() > 0)
                {
                    m_fireRate = 0;
                    RaycastHit hit;
                    if (Physics.Raycast(_posShoot.position, (_posAim.position - _posShoot.position), out hit, Mathf.Infinity))
                    {
                        Debug.Log("Shoot");
                        _amBullet.Shoot();
                    }
                    return true;
                }
            }
            return false;
        }


        public override void Recharge()
        {
            _amBullet.Reload();
        }
    }
}

