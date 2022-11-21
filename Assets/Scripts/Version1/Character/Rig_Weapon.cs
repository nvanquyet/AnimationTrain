using Assets.Scripts.AnimtionScripts;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Assets.Scripts.Character
{
    public class Rig_Weapon : MonoBehaviour
    {
        [SerializeField] private AnimationCtrl _animationCtrl;

        [Header("Rig Properties")]
        [SerializeField] private GameObject _gunAKM;
        [SerializeField] private GameObject _LHandIK;
        [SerializeField] private GameObject _RHandIK;
        [SerializeField] public GameObject _body;

        // Start is called before the first frame update
        void Start()
        {
            _RHandIK.GetComponent<MultiAimConstraint>().weight = 0;
        }
        // Update is called once per frame
        void Update()
        {
            Sprint();   
        }
        public void Sprint()
        {
            if (_animationCtrl.GetSprint() == true)
            {
                _gunAKM.SetActive(true);
                if (!_animationCtrl.GetReload())
                {
                    _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = Mathf.Lerp(_LHandIK.GetComponent<TwoBoneIKConstraint>().weight,
                        1, Time.deltaTime * 2);
                }
                else
                {
                    _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = Mathf.Lerp(_LHandIK.GetComponent<TwoBoneIKConstraint>().weight,
                    0, Time.deltaTime * 2);
                }
                this.SetOffset(new Vector3(0, 42.5f, 0));
            }
            else
            {
                _gunAKM.SetActive(false);
                _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = Mathf.Lerp(_LHandIK.GetComponent<TwoBoneIKConstraint>().weight,
                    0, Time.deltaTime * 2);
                this.SetOffset(Vector3.zero);
            }
        }
        public GameObject GetRHand()
        {
            return _RHandIK;
        }

        public GameObject GetLHand()
        {
            return _LHandIK;
        }
        public void SetOffset(Vector3 offset)
        {
            _body.GetComponent<MultiAimConstraint>().data.offset = Vector3.Lerp(_body.GetComponent<MultiAimConstraint>().data.offset,
                offset, Time.deltaTime * 10);
        }
    }
}
