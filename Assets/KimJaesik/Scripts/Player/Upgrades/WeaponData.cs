using UnityEngine;
using System;

namespace KJS
{
    [System.Serializable]
    public class WeaponData
    {
        public string weaponName;
        public string description;
        public Sprite icon;
        public GameObject weaponObject;  // Player ������ ���� ������Ʈ
        public Action upgradeAction;     // ���׷��̵� ��� (��������Ʈ)

        public void ActivateWeapon()
        {
            if (weaponObject != null)
                weaponObject.SetActive(true);
        }

        public void UpgradeWeapon()
        {
            upgradeAction?.Invoke();  // ���׷��̵� ��� ȣ��
        }
    }
}
