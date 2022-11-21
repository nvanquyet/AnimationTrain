using UnityEngine;
using System.Collections;

namespace Assets.Scripts.BulletScripts
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(DestroyObject());
        }
        IEnumerator DestroyObject()
        {
            yield return new WaitForSeconds(1.5f);
            this.gameObject.SetActive(false);
        }
    }

}
    