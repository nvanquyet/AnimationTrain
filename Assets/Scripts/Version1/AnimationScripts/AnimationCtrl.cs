using System.Collections;
using Assets.Scripts.State;
using UnityEngine;

namespace Assets.Scripts.AnimtionScripts
{
    public class AnimationCtrl : MonoBehaviour
    {
        [SerializeField] private ControlState _state;
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isShoot;
        [SerializeField] private bool _isSprint;
        [SerializeField] private bool _isRun;
        [SerializeField] private bool _isCrounch;
        [SerializeField] private bool _isReload;
        [SerializeField] private Transform _followPos;
        [SerializeField] private float _distancePosUpAnDown;
        private float _posMax;

        private void Start()
        {
            _isShoot = false;
            _isReload = false;
            _isSprint = false;
            _isCrounch = false;
            _isRun = false;
            if(_followPos != null)
            {
                _posMax = _followPos.position.y;
            }
        }
        public void SetSprint()
        {
            this._isSprint = !this._isSprint;
        }
        private void Run(float vertical)
        {
            if (vertical >= 0)
            {
                _animator.SetBool("Run", _isRun);
            }
            else
            {
                _animator.SetBool("Run", false);
            }
        }
        public void Sprint()
        {
            if (_isSprint)
            {
                SetSmoothLayerWeight(1, 1);
                if (_isShoot || _state.GetCurrentState().GetType().Equals(_state.aim.GetType()) || _isReload)
                {
                    SetSmoothLayerWeight(2, 1);
                }
                else
                {
                    SetSmoothLayerWeight(2, 0);
                }

                _animator.SetBool("Crounch", _isCrounch);
            }
            else
            {
                SetSmoothLayerWeight(1, 0);
            }
        }
        public void SetSmoothLayerWeight(int indexLayer,float value)
        {
            _animator.SetLayerWeight(indexLayer, Mathf.Lerp(_animator.GetLayerWeight(indexLayer), value, Time.fixedDeltaTime * 15f));
        }
        public void SetShoot(bool codition)
        {
            this._isShoot = codition;
            this._animator.SetBool("Shoot", codition);
        }
        public void SetCrounch()
        {
            if (this._isSprint)
            {
                this._isCrounch = !this._isCrounch;
            }
            if (this._isCrounch)
            {
                if(_followPos.position.y == _posMax)
                {
                    _followPos.position -= new Vector3(0, _distancePosUpAnDown, 0);
                }
            }
            else
            {
                if (_followPos.position.y == _posMax-_distancePosUpAnDown)
                {
                    _followPos.position += new Vector3(0, _distancePosUpAnDown, 0);
                }
            }
        }
        public void SetRun(bool codition)
        {
            this._isRun = codition;
        }
        public bool GetRun()
        {
            return this._isRun;
        }
        public bool GetSprint()
        {
            return this._isSprint;
        }
        public void SetVelocity(float horizontal,float vertical)
        {
            this.Run(vertical);
            _animator.SetFloat("Horizontal", horizontal);
            _animator.SetFloat("Vertical", vertical);
        }

        public ControlState GetState()
        {
            return _state;
        }
        public void SetReload()
        {
            this._isReload = !_isReload;
        }

        public bool GetReload()
        {
            return this._isReload;
        }

        public Animator GetAnimator()
        {
            return _animator;
        }


    }
}
