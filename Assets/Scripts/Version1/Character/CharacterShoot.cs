using UnityEngine;
using UnityEngine.Animations.Rigging;
using Assets.Scripts.State;
using Assets.Scripts.ObjectPooling;
using Assets.Scripts.AnimtionScripts;
using Assets.Scripts.BulletScripts;
using System.Collections;

namespace Assets.Scripts.Character
{
    public class CharacterShoot : MonoBehaviour
    {
        [SerializeField] private AnimationCtrl _anim;
        [Header("Fire rate")]
        public float _fireRate;
        private float m_fireRate;
        [Header("Bullet Properties")]
        [SerializeField] private AmmoBullet _amBullet;
        [SerializeField] private GameObject _gun;
        [SerializeField] private Transform _posShoot;
        [SerializeField] private Transform _posAim;
        [SerializeField] private int _numberInTurn;
        [SerializeField] private float speed;

        // Start is called before the first frame update
        void Start()
        {
            m_fireRate = 0;
        }
        // Update is called once per frame
        void Update()
        {
            if (!_gun.activeSelf)
            {
                return;
            }
            if (ReadyToShoot())
            {
                Shoot();
            }
        }
        bool ReadyToShoot()
        {
            m_fireRate += Time.deltaTime;
            if (m_fireRate < _fireRate)
            {
                return false;
            }
            if (_amBullet.GetCurrentAmmo() > 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0))
                {
                    _anim.SetShoot(true);
                    return true;
                }
            }
            _anim.SetShoot(false);
            return false;
        }
        void Shoot()
        {
            m_fireRate = 0;
            for (int i = 0; i < _numberInTurn; i++)
            {
                GameObject _bulletObj = ObjectPool.SharedInstance.GetPooledObject();
                _posShoot.parent.forward = _posAim.position - _posShoot.position;
                if (_bulletObj)
                {
                    _bulletObj.transform.position = _posShoot.position;
                    _bulletObj.SetActive(true);
                    _bulletObj.GetComponent<Rigidbody>().AddForce((_posAim.position - _posShoot.position)* speed);
                    _amBullet.Shoot();
                }
            }
        }
        public AmmoBullet GetAmmo()
        {
            return this._amBullet;
        }

        public void Reloading(float _timeReload)
        {
            if(_amBullet.GetAmount() > 0 && _amBullet.GetCurrentAmmo() < _amBullet.GetAmmoInturn())
            {
                if (!_anim.GetSprint())
                {
                    return;
                }
                this._anim.SetReload();
                _anim.GetAnimator().SetTrigger("Reload");
                StartCoroutine(ReloadComplete(_timeReload));
            }
        }
        IEnumerator ReloadComplete(float _timeReload)
        {
            yield return new WaitForSeconds(_timeReload);
            Debug.Log("Reload Complete");
            this._anim.SetReload();
        }
    }
}
