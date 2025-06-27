using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace AJH {
    [System.Serializable]
    public class UpgradeSlot
    {
        public Button button;
        public Text costText;
        public Text statText;
        public StatData statData;
    }

    public class UpgradeManager : MonoBehaviour
    {
        public UpgradeSlot[] slots;
        public Text totalMoneyText;

        void Start()
        {
            foreach (var slot in slots)
            {
                int level = PlayerPrefs.GetInt(slot.statData.statName + "_Level", 0);
                UpdateSlotUI(slot, level);

                slot.button.onClick.AddListener(() =>
                {
                    Upgrade(slot);
                });
            }

            UpdateTotalMoney();
        }

        void Upgrade(UpgradeSlot slot)
        {
            int level = PlayerPrefs.GetInt(slot.statData.statName + "_Level", 0);
            if (level >= slot.statData.upgradeValues.Length) return;

            int cost = slot.statData.upgradeCosts[level];
            if (GameManager.instance.totalMoney >= cost)
            {
                GameManager.instance.totalMoney -= cost;
                PlayerPrefs.SetFloat("TotalMoney", GameManager.instance.totalMoney);
                level++;
                PlayerPrefs.SetInt(slot.statData.statName + "_Level", level);
                PlayerPrefs.Save();

                ApplyUpgrade(slot.statData.statName, level);
                UpdateSlotUI(slot, level);
                UpdateTotalMoney();
            }
        }

        void UpdateSlotUI(UpgradeSlot slot, int level)
        {
            if (level >= slot.statData.upgradeValues.Length)
            {
                slot.costText.text = "Max";
                slot.button.interactable = false;
            }
            else
            {
                slot.costText.text = slot.statData.upgradeCosts[level].ToString()+"\\";
            }
            float currentValue = slot.statData.upgradeValues[level];
            float nextValue = level < slot.statData.upgradeValues.Length - 1 ? slot.statData.upgradeValues[level + 1] : currentValue;
            switch (slot.statData.statName)
            {
                case "Speed":
                    slot.statText.text = $"현재:{currentValue}->{nextValue}";
                    break;
                case "Defense":
                    slot.statText.text = $"현재:{currentValue}->{nextValue}";
                    break;
                case "Gold":
                    slot.statText.text = $"증가량:{(int)(nextValue*100)}%";
                    break;
            }
        }

        void UpdateTotalMoney()
        {
            totalMoneyText.text = $"보유잔액: {GameManager.instance.totalMoney}\\";
        }

        void ApplyUpgrade(string statName, int level)
        {
            float value = 0f;
            switch (statName)
            {
                case "Speed":
                    value = Resources.Load<StatData>("Speed").upgradeValues[level - 1];
                    player.Instance.moveSpeed = value;
                    break;
                case "Defense":
                    value = Resources.Load<StatData>("Defense").upgradeValues[level - 1];
                    GameManager.instance.defense = value;
                    break;
                case "Gold":
                    value = Resources.Load<StatData>("Gold").upgradeValues[level - 1];
                    GameManager.instance.moneyIncrease = value;
                    break;
            }
        }
    }

    
    
}