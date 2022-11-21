using Assets.Scripts.BulletScripts;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Weapon
{
    public class Melee : Weapon
    {
        public override bool Attack()
        {
            if (ReadyToAttack())
            {
                m_fireRate = 0;
                return true;
            }
            return false;
        }
    }
}

