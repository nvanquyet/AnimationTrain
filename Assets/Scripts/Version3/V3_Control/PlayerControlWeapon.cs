using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Version3.State;
using Assets.Scripts.Version3.State.State;
using Assets.Scripts.Version3.V3_Input;
using UnityEngine;

namespace Assets.Scripts.Version3.V3_Control
{
    public class PlayerControlWeapon : MyBehaviour
    {
        [Header("Input")]
        [SerializeField] private InputCtrl _inputCtrl;

        [Header("Weapon")]
        [SerializeField] private List<GameObject> weaponList = new List<GameObject>();
        [SerializeField] private List<Transform> weaponPosNoEq = new List<Transform>();
        [SerializeField] private List<Transform> weaponPosEq = new List<Transform>();
        [SerializeField] private int selectedWeapon;
        int previousSelect = -1;
        public TypeChange typeChange { get; set; }
        public TypeEquiq typeEquiq { get; set; }

        private void Awake()
        {
            _inputCtrl = GetComponentInChildren<InputCtrl>();
            foreach (Transform child in GameObject.Find("Weapon").transform)
            {
                weaponList.Add(child.gameObject);
                child.gameObject.SetActive(true);
            }
            foreach (Transform child in GameObject.Find("PosWeaponEquiq").transform)
            {
                weaponPosEq.Add(child);
            }
            foreach (Transform child in GameObject.Find("PosWeaponNoEquiq").transform)
            {
                weaponPosNoEq.Add(child);
            }
        }

        public override void LoadComponent()
        {
            selectedWeapon = 0;
            typeChange = TypeChange.NoChange;
            ChangeWeapon(-1);
        }

        public void ChangeWeapon(int index)
        {
            int i = 0;
            foreach(GameObject child in weaponList)
            {
                if (i == index)
                {
                    child.transform.SetParent(GameObject.Find("Weapon").transform);
                    child.transform.position = weaponPosEq[index].position;
                    child.transform.rotation = weaponPosEq[index].rotation;
                    child.transform.localScale = weaponPosEq[index].localScale;
                }
                else
                {
                    child.transform.SetParent(GameObject.Find("WeaponNoEquiq").transform);
                    child.transform.position = weaponPosNoEq[i].position;
                    child.transform.rotation = weaponPosNoEq[i].rotation;
                    child.transform.localScale = weaponPosNoEq[i].localScale;
                }
                i++;
            }
        }

        public bool WeponControl()
        {
            if (weaponList.Count == 0)
            {
                return false;
            }
            if (_inputCtrl.ChangeWeaponByMouse < 0)
            {
                if (selectedWeapon <= 0)
                {
                    selectedWeapon = weaponList.Count - 1;
                }
                else
                {
                    selectedWeapon--;
                }
            }
            if (_inputCtrl.ChangeWeaponByMouse > 0)
            {
                if (selectedWeapon >= weaponList.Count - 1)
                {
                    selectedWeapon = 0;
                }
                else
                {
                    selectedWeapon++;
                }
            }
            if (_inputCtrl.ChangeWeaponByKeyCode(KeyCode.Alpha1))
            {
                selectedWeapon = 0;
            }
            if (_inputCtrl.ChangeWeaponByKeyCode(KeyCode.Alpha2) && weaponList.Count >= 2)
            {
                selectedWeapon = 1;
            }
            if (_inputCtrl.ChangeWeaponByKeyCode(KeyCode.Alpha3) && weaponList.Count >= 3)
            {
                selectedWeapon = 2;
            }
            if (previousSelect != selectedWeapon)
            {
                previousSelect = selectedWeapon;
                switch (selectedWeapon)
                {
                    case 0:
                        {
                            typeChange = TypeChange.ChangeGun1;
                            break;
                        }
                    case 1:
                        {
                            typeChange = TypeChange.ChangeGun2;
                            break;
                        }
                    case 2:
                        {
                            typeChange = TypeChange.ChangeMelee;
                            break;
                        }
                }
                ChangeWeapon(selectedWeapon);
                return true;
            }
            return false;
        }

        public GameObject GetWeapon()
        {
            if(selectedWeapon < 0)
            {
                return weaponList[0];
            }
            return weaponList[selectedWeapon];
        }

        public int GetSelectedWeapon()
        {
            return selectedWeapon;
        }
    }
}
