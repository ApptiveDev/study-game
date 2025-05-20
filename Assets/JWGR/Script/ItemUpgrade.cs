using JWGR;
using UnityEngine;

namespace JWGR
{
    public class ItemUpgrade : MonoBehaviour
    {
        private int level = 0;
        private ItemData itemData;

        void Awake()
        {
            itemData = GetComponent<ItemData>();
            ResetLevel(); // 게임 시작 시 레벨 초기화
        }

        private void ResetLevel()
        {
            level = 0;
            itemData.weaponLevel = level;
        }

        public void Upgrades()
        {
            itemData.weaponLevel += 1;
            level = itemData.weaponLevel;
            ApplyLevel();
        }

        public void StartSet()
        {
            level = itemData.weaponLevel;
            ApplyLevel();
        }

        private void ApplyLevel()
        {
            //itemData.canSpawn = level >= 1; // 레벨이 1 이상이면 활성화
            if (level >= 1)
            {
                itemData.canSpawn = true; // Object 활성화
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