using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Graphics
{
    public class ShootingEffect : MonoBehaviour
    {
        [Header("FX")]
        [SerializeField] private ParticleSystem shootFx;
        [SerializeField] private TrailRenderer _bulletTrail;
        [SerializeField] private Transform posEnd;

        private void Start()
        {
            SetFX();   
        }

        public void SetFX()
        {
            shootFx = GetComponentInChildren<ParticleSystem>();
        }

        public void PlayFX(string fx)
        {
            switch (fx)
            {
                case "Shoot":
                    {
                        if(shootFx != null)
                        {
                            shootFx.Play();
                        }
                        else
                        {
                            shootFx = GetComponentInChildren<ParticleSystem>();
                        }
                        if (_bulletTrail)
                        {
                            TrailRenderer trail = Instantiate(_bulletTrail, transform.position, Quaternion.identity);
                            trail.transform.SetParent(this.transform);
                            StartCoroutine(StopFx(Time.deltaTime,trail, posEnd));
                        }
                        break;
                    }
                case "Bullet":
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        IEnumerator StopFx(float time,TrailRenderer trail,Transform endPoint)
        {
            yield return new WaitForSeconds(time);
            trail.transform.position = endPoint.position;
            Destroy(trail.gameObject, 0.04f);
        }
    }
}
