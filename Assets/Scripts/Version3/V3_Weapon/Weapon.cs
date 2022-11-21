using UnityEngine;

namespace Assets.Scripts.Version3.V3_Weapon
{
    public enum TypeOfWeapon
    {
        HandAttack,
        Melee,
        Gun
    }
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Fire rate")]
        public float _fireRate;
        protected float m_fireRate;
        public float timeReload;

        private void Update()
        {
            ReadyToAttack();
        }
        public bool ReadyToAttack()
        {
            if(m_fireRate < _fireRate)
            {
                m_fireRate += Time.deltaTime;
                return false;
            }
            return true;
        }

        public abstract bool Attack();
        public virtual void Recharge()
        {

        }
    }
}

