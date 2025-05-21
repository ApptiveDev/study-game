using JWGR;
using UnityEngine;

namespace JWGR
{
    public class ItemUpgrade : MonoBehaviour
    {
        private int level = 0;
        private ItemData itemData;

        private void ResetLevel()
        {
            level = 0;
            itemData.weaponLevel = level;
        }

        public void Upgrades()
        {
            itemData = GetComponent<ItemData>();
            itemData.weaponLevel += 1;
            level = itemData.weaponLevel;
            ApplyLevel();
        }

        public void StartSet()
        {
            itemData = GetComponent<ItemData>();
            level = 0;
            itemData.weaponLevel = level;
            ApplyLevel();
        }

        private void ApplyLevel()
        {
            //itemData.canSpawn = level >= 1; // 레벨이 1 이상이면 활성화
            if (level >= 1)
            {
                itemData.canSpawn = true; // Object 활성화
            }
            else
            {
                itemData.canSpawn = false;
            }

            if (level < itemData.damages.Length)
            {
                itemData.damage = itemData.damages[level];
            }
            if (level < itemData.counts.Length)
            {
                itemData.count = itemData.counts[level];
            }
            if (level < itemData.speeds.Length)
            {
                itemData.speed = itemData.speeds[level];
            }

            if (level < itemData.itemDescs.Length)
            {
                itemData.itemDesc = itemData.itemDescs[level];
            }
            itemData.itemState = level > 0 ? "Lv." + level.ToString() : "New!";
        }
    }
}