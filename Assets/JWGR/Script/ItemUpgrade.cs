using JWGR;
using UnityEngine;

namespace JWGR
{
    public class ItemUpgrade : MonoBehaviour
    {
        private int weaponLevel = 0;
        private ItemData itemData;

        void Start()
        {
            itemData = GetComponent<ItemData>();
            weaponLevel = itemData.weaponLevel;
            if (weaponLevel <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        public void Upgrades()
        {
            itemData = GetComponent<ItemData>();
            itemData.weaponLevel += 1;  
            weaponLevel = itemData.weaponLevel;
            if (weaponLevel == 1)
            {
                gameObject.SetActive(true);
            }
            else if (weaponLevel >= 2)
            {
                if (weaponLevel < itemData.damages.Length)
                {
                    itemData.damage = itemData.damages[weaponLevel - 2];
                }
                if (weaponLevel < itemData.counts.Length)
                {
                    itemData.count = itemData.counts[weaponLevel - 2];
                }
                if (weaponLevel < itemData.speeds.Length)
                {
                    itemData.speed = itemData.speeds[weaponLevel - 2];
                }
            }

            if (weaponLevel < itemData.itemDescs.Length)
            {
                itemData.itemDesc = itemData.itemDescs[weaponLevel - 1];
            }
            if (weaponLevel > 0)
            {
                itemData.itemState = "Lv." + weaponLevel.ToString();
            }
            else
            {
                itemData.itemState = "New!";
            }
        }
    }
}