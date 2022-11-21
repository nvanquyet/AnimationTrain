/*using Assets.Scripts.BulletScripts;
using Assets.Scripts.Version2.GraphicsManagers.Animation;
using Assets.Scripts.Version2.GraphicsManagers.Graphics;
using Assets.Scripts.Version2.State.StateLayer;
using UnityEngine;

namespace Assets.Scripts.ControlManager.Attack
{
    public class PlayerAttack : MonoBehaviour, IPlayerAttack
    {
        [Header("Fire rate")]
        public float _fireRate;
        private float m_fireRate;

        [Header("Bullet Properties")]
        [SerializeField] private Transform _posShoot;
        [SerializeField] private Transform _posAim;
        [SerializeField] private int _numberInTurn;

        [Header("FX")]
        [SerializeField] private ShootingEffect _shootingEffect;

        [Header("Animation")]
        [SerializeField] private AnimationLayer animationLayer;
        [SerializeField] private ObjectProperties objectProperties;
        [SerializeField] private StateLayer stateLayer;
        [SerializeField] private bool isReload;

        private void Awake()
        {
           // _amBullet = GetComponentInChildren<AmmoBullet>();
            animationLayer = GetComponentInChildren<AnimationLayer>();
            objectProperties = GetComponentInChildren<ObjectProperties>();
            _shootingEffect = GetComponentInChildren<ShootingEffect>();
        }

        private void Start()
        {
            m_fireRate = 0;
           // direction = Vector3.zero;
            
        }

        private void Update()
        {
            ReadyToAttack();
           // direction = _posAim.position - _posShoot.position;
            Debug.DrawRay(_posShoot.position, (_posAim.position - _posShoot.position), Color.grey);
        }

        public void SetStateLayer(StateLayer state, bool reload)
        {
            animationLayer.ControlLayer(state, reload);
            objectProperties.ActiveObject(state, reload);
        }

        *//*public bool ReadyToAttack()
        {
          /*  if (_amBullet.GetCurrentAmmo() <= 0)
            {
                return false;
            }
            if (m_fireRate < _fireRate)
            {
                m_fireRate += Time.deltaTime;
                return false;
            }
            return true;*/
        

       /* public void Attack()
        {
            if (ReadyToAttack())
            {
                _shootingEffect.PlayFX("Shoot");
                _shootingEffect.PlayFX("Bullet");
                stateLayer = StateLayer.HaveWeaponSaR;
                m_fireRate = 0;
                RaycastHit hit;
                if(Physics.Raycast(_posShoot.position, (_posAim.position - _posShoot.position), out hit, Mathf.Infinity))
                {
                    Debug.Log(hit.collider.name);
                    _shootingEffect.StopFX("Bullet");
                }
                SetStateLayer(stateLayer, false);
            }
        }*//*

        
    }


    public interface IPlayerAttack
    {
        public bool ReadyToAttack();
        public void Attack();
        public void SetStateLayer(StateLayer state, bool reload);
    }
}
*/