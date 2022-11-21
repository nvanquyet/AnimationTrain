using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Version2.GraphicsManagers.Graphics
{
    public class ShootingEffect : MonoBehaviour
    {

        [Header("FX")]
        [SerializeField] private ParticleSystem shootFx;
        [SerializeField] private ParticleSystem shootVFx;

        private void Awake()
        {
           /* shootFx = transform.GetChild(0).GetComponent<ParticleSystem>();
            shootVFx = transform.GetChild(1).GetComponent<ParticleSystem>();*/
        }

        public void PlayFX(string fx)
        {
            switch (fx)
            {
                case "Shoot":
                    {
                        shootFx.Play();
                        break;
                    }
                case "Bullet":
                    {
                        shootVFx.Play();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void StopFX(string fx)
        {
            switch (fx)
            {
                case "Shoot":
                    {
                        StopFx(shootFx,Time.deltaTime);
                        shootFx.Stop();
                        break;
                    }
                case "Bullet":
                    {
                        StopFx(shootVFx, Time.deltaTime);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        IEnumerator StopFx(ParticleSystem fx, float time)
        {
            yield return new WaitForSeconds(time);
            fx.Stop();
        }
    }
}
