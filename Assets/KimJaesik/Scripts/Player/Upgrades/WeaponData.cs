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
        public GameObject weaponObject;  // Player 하위의 무기 오브젝트
        public Action upgradeAction;     // 업그레이드 방식 (델리게이트)

        public void ActivateWeapon()
        {
            if (weaponObject != null)
                weaponObject.SetActive(true);
        }

        public void UpgradeWeapon()
        {
            upgradeAction?.Invoke();  // 업그레이드 방식 호출
        }
    }
}
