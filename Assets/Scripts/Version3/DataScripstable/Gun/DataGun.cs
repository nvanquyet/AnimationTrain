using UnityEngine;
namespace Assets.Scripts.Version3.DataScripstable.Gun
{
    [CreateAssetMenu(fileName = "DataGun", menuName = "ScriptableObjects/Data")]
    public abstract class DataGun : ScriptableObject
    {
        public float timeReload;
        public float fireRate;
        public float numberBulletInTurn;

        public abstract float GetTimeReload();
        public abstract float GetFireRate();
        public abstract float GetNumberInturn();
    }
}

