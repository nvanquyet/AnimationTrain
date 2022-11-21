using Assets.Scripts.Version2.State.State;
using Assets.Scripts.Version2.State.StateLayer;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Assets.Scripts.Version2.GraphicsManagers.Graphics
{
    public class ObjectProperties : MonoBehaviour, IObjectProp
    {
        [SerializeField] private GameObject _gunAKM;
        [SerializeField] private GameObject _LHandIK;
        [SerializeField] private GameObject _RHandIK;
        [SerializeField] private Vector3 offset;
        public GameObject _body;
        public void ActiveObject(StateLayer stateLayer, bool isReload = false)
        {
            if (stateLayer.Equals(StateLayer.NoWeapon))
            {
                _gunAKM.SetActive(false);
                _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = Mathf.Lerp(_LHandIK.GetComponent<TwoBoneIKConstraint>().weight,
                    0, Time.deltaTime * 2);
                this.SetOffset(Vector3.zero);
            }
            else
            {
                _gunAKM.SetActive(true);
                if (isReload)
                {
                    _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = 0;
                }
                else
                {
                    _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = 1;
                    if (stateLayer.Equals(StateLayer.HaveWeaponS) || stateLayer.Equals(StateLayer.HaveWeaponR))
                    {
                        _RHandIK.GetComponent<MultiAimConstraint>().weight = 1;
                    }
                    else
                    {
                        _RHandIK.GetComponent<MultiAimConstraint>().weight = 0;
                    }
                }
                this.SetOffset(offset);
            }
        }

        public void SmoothWeight(float weight)
        {
            throw new System.NotImplementedException();
        }

        public void SetOffset(Vector3 offset)
        {
            _body.GetComponent<MultiAimConstraint>().data.offset = Vector3.Lerp(_body.GetComponent<MultiAimConstraint>().data.offset,
                offset, Time.deltaTime * 10);
        }


    }
}
