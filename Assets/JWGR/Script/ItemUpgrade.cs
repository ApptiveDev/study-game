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
            itemData = GetComponent<ItemData>();
            itemData.weaponLevel += 1;
            level = itemData.weaponLevel;
            ApplyLevel();
        }

        private void ApplyLevel()
        {
            itemData.canSpawn = level >= 1; // 레벨이 1 이상이면 활성화
            //if (level >= 1)
            //{
            //    gameObject.SetActive (true);
            //}

            if (level >= 2)
            {
                if (level - 2 < itemData.damages.Length)
                {
                    itemData.damage = itemData.damages[level - 2];
                }
                if (level - 2 < itemData.counts.Length)
                {
                    itemData.count = itemData.counts[level - 2];
                }
                if (level - 2 < itemData.speeds.Length)
                {
                    itemData.speed = itemData.speeds[level - 2];
                }
            }

            if (level - 1 < itemData.itemDescs.Length)
            {
                itemData.itemDesc = itemData.itemDescs[level - 1];
            }
            itemData.itemState = level > 0 ? "Lv." + level.ToString() : "New!";
        }
    }
}