using JWGR;
using UnityEngine;

namespace JWGR
{
    public class ItemUpgrade : MonoBehaviour
    {
        private int level = 0;
        private ItemData itemData;

        void Start()
        {
            itemData = GetComponent<ItemData>();
            level = itemData.weaponLevel;
            if (level <= 0)
            {
                gameObject.GetComponent<ItemData>().canSpawn = false;
            }
        }

        public void Upgrades()
        {
            itemData = GetComponent<ItemData>();
            itemData.weaponLevel += 1;  
            level = itemData.weaponLevel;
            if (level == 1)
            {
                gameObject.GetComponent<ItemData>().canSpawn = true;
            }
            else if (level >= 2)
            {
                if (level < itemData.damages.Length)
                {
                    itemData.damage = itemData.damages[level - 2];
                }
                if (level < itemData.counts.Length)
                {
                    itemData.count = itemData.counts[level - 2];
                }
                if (level < itemData.speeds.Length)
                {
                    itemData.speed = itemData.speeds[level - 2];
                }
            }

            if (level < itemData.itemDescs.Length)
            {
                itemData.itemDesc = itemData.itemDescs[level - 1];
            }
            if (level > 0)
            {
                itemData.itemState = "Lv." + level.ToString();
            }
            else
            {
                itemData.itemState = "New!";
            }
        }
    }
}