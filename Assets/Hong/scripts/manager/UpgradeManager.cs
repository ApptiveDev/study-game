using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        private float totalMoney = 0;
        public Button upgradeButton;

        void Start()
        {
            InitializeStatPrefs();
            UpdateTotalMoney();
            foreach (var slot in slots)
            {
                int level = PlayerPrefs.GetInt(slot.statData.statName + "_Level", 0);
                UpdateSlotUI(slot, level);

                slot.button.onClick.AddListener(() =>
                {
                    Upgrade(slot);
                });
            }
            upgradeButton.onClick.AddListener(() =>
            {
                GoToTitle();
            });

        }
        public void GoToTitle()
        {
            SceneManager.LoadScene("title");
        }

        void Upgrade(UpgradeSlot slot)
        {
            int level = PlayerPrefs.GetInt(slot.statData.statName + "_Level", 0);
            if (level >= slot.statData.upgradeValues.Length) return;

            int cost = slot.statData.upgradeCosts[level];
            if (totalMoney >= cost)
            {
                totalMoney -= cost;
                PlayerPrefs.SetFloat("TotalMoney", GameManager.instance.totalMoney);
                level++;
                PlayerPrefs.SetInt(slot.statData.statName + "_Level", level);
                PlayerPrefs.Save();

                UpdateTotalMoney();
                UpdateSlotUI(slot, level);
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
                slot.costText.text = slot.statData.upgradeCosts[level].ToString() + "원";
            }
            float currentValue = level > 0 ? slot.statData.upgradeValues[level - 1] : slot.statData.baseValue;
            float nextValue = level < slot.statData.upgradeValues.Length
                ? slot.statData.upgradeValues[level]
                : currentValue;

            switch (slot.statData.statName)
            {
                case "Speed":
                    slot.statText.text = $"현재:{currentValue}->{nextValue}";
                    break;
                case "Defense":
                    slot.statText.text = $"현재:{currentValue}->{nextValue}";
                    break;
                case "Gold":
                    slot.statText.text = $"증가량:{(int)(nextValue * 100)}%";
                    break;
            }
        }

        void UpdateTotalMoney()
        {
            
            if (PlayerPrefs.HasKey("TotalMoney") == false)
            {
                PlayerPrefs.SetFloat("TotalMoney", 0f);
            }
            else
            {
                totalMoney = PlayerPrefs.GetFloat("TotalMoney");
            }

            totalMoneyText.text = $"보유잔액: {totalMoney}원";
        }


        

        private void InitializeStatPrefs()
        {
            string[] stats = { "Speed", "Defense", "Gold" };
            foreach (string stat in stats)
            {
                if (!PlayerPrefs.HasKey(stat + "_Level"))
                {
                    PlayerPrefs.SetInt(stat + "_Level", 0);
                }
            }
            if (!PlayerPrefs.HasKey("TotalMoney"))
            {
                PlayerPrefs.SetFloat("TotalMoney", 0f);
            }
        }
    }

    
    
}