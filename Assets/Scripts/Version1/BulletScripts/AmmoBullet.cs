using UnityEngine;

namespace Assets.Scripts.BulletScripts
{
    public class AmmoBullet : MonoBehaviour
    {
        private int _currentAmount;
        [SerializeField] private int _amountInTurn;
        [SerializeField] private int _amount;
        private void Start()
        {
            _currentAmount = _amountInTurn;
        }

        public void Shoot()
        {
            if(_currentAmount > 0)
            {
                _currentAmount--;
            }
        }

        public int GetCurrentAmmo()
        {
            return this._currentAmount;
        }

        public int GetAmmoInturn()
        {
            return this._amountInTurn;
        }

        public void SetAmmoInturn(int number)
        {
            this._amountInTurn = number;
        }


        public int GetAmount()
        {
            return this._amount;
        }

        public void Reload()
        {
            int numberToFull = _amountInTurn - _currentAmount;
            if(numberToFull > 0 && _amount > 0)
            {
                if (numberToFull < _amount)
                {
                    _currentAmount += numberToFull;
                    _amount -= numberToFull;
                }
                else
                {
                    _currentAmount += _amount;
                    _amount = 0;
                }
            }
        }

    }
}
