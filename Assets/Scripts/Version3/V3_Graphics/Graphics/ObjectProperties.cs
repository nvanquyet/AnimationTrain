using Assets.Scripts.Version3.State;
using Assets.Scripts.Version3.V3_Control;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Assets.Scripts.Version3.V3_Graphics
{
    public class ObjectProperties : MyBehaviour
    {
        [SerializeField] private PlayerAttack _player;
        [SerializeField] private GameObject _LHandIK;
        [SerializeField] private GameObject _RHandIK;
        [SerializeField] private Vector3 offset;
        public GameObject _body;


        public override void LoadComponent()
        {
            _player = GetComponentInParent<PlayerAttack>();
            _RHandIK = transform.Find("Rig Layer").GetChild(2).GetChild(0).gameObject;
            _LHandIK = transform.Find("Rig Layer").GetChild(2).GetChild(1).gameObject;
        }

        private void Update()
        {
            ActiveObject(_player.weaponCtrl.typeEquiq,_player.weaponCtrl.GetWeapon(), _player.typeAttack);
        }
        public void ActiveObject(TypeEquiq typeEquiq,GameObject weapon, TypeAttack typeAttack)
        {
            switch (typeEquiq)
            {
                case TypeEquiq.NoWeapon:
                    {
                        _player.weaponCtrl.ChangeWeapon(-1);
                        _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = Mathf.Lerp(_LHandIK.GetComponent<TwoBoneIKConstraint>().weight,
                            0, Time.deltaTime * 2);
                        _body.transform.parent.GetComponent<Rig>().weight = 0.2f;
                        break;
                    }
                case TypeEquiq.Melee:
                    {
                        _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = 0;
                        break;
                    }
                case TypeEquiq.Gun:
                    {
                        if (typeAttack.Equals(TypeAttack.Recharge))
                        {
                            _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = 0;
                        }
                        else
                        {
                            _LHandIK.GetComponent<TwoBoneIKConstraint>().weight = 1;
                        }
                        if (typeAttack.Equals(TypeAttack.GunAttack))
                        {
                            _RHandIK.GetComponent<MultiAimConstraint>().weight = 1;
                        }
                        else
                        {
                            _RHandIK.GetComponent<MultiAimConstraint>().weight = 0;
                        }
                        _body.transform.parent.GetComponent<Rig>().weight = 0.75f;
                        _body.GetComponent<MultiAimConstraint>().data.offset = Vector3.Lerp(_body.GetComponent<MultiAimConstraint>().data.offset,
                            offset, Time.deltaTime * 10);
                        break;
                    }
            }
            
        }

    }
}
