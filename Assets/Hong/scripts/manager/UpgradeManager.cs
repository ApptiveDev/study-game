using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace AJH {

    public class UpgradeManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public StatData statData; // 스탯 데이터
        private moneyText moneyText; // 돈 텍스트 UI
        public Button upgradeButton;
        public Text upgradeCostText; // 업그레이드 비용 텍스트
        public Text upgradeStatText; // 현재 스탯 텍스트


        private int currentLevel; // 현재 업그레이드 레벨
        private float[] values => statData.upgradeValues; // 레벨에 따른 값 배열
        private int[] costs => statData.upgradeCosts; // 업그레이드 비용 배열

        void Start()
        {
            currentLevel = PlayerPrefs.GetInt(statData.statName + "_Level", 0);
            UpdateUI();

            upgradeButton.onClick.AddListener(Upgrade);
        }

        // Update is called once per frame

        private void Upgrade()
        {
            if (currentLevel >= values.Length) return;
            float cost = costs[currentLevel];
            if (GameManager.instance.totalMoney >= cost)
            {
                GameManager.instance.totalMoney -= cost; // 코인 차감
                currentLevel++;
                PlayerPrefs.SetInt(statData.statName + "_Level", currentLevel); // 레벨 저장
                PlayerPrefs.SetFloat("TotalMoney", GameManager.instance.totalMoney); // 총 돈 저장
                PlayerPrefs.Save(); // PlayerPrefs 저장

                ApplyUpgrade();
                UpdateUI();
            }
        }

        void ApplyUpgrade()
        {
            switch (statData.statName)
            {
                case "Speed":
                    player.Instance.moveSpeed = values[currentLevel]; // 플레이어 이동 속도 업그레이드
                    break;
                case "Defense":
                    // Barrier 관련 로직 추가
                    GameManager.instance.defense = values[currentLevel]; // 방어력 업그레이드
                    break;
                case "Gold":
                    GameManager.instance.moneyIncrease = values[currentLevel]; // 돈 증가량 업그레이드
                    break;
                default:
                    Debug.LogWarning("Unknown stat type: " + statData.statName);
                    break;
            }

        }

        private void UpdateUI()
        {
            moneyText.updateMoneyText(); // 돈 텍스트 업데이트
            if (currentLevel >= values.Length)
            {
                upgradeButton.interactable = false; // 업그레이드 버튼 비활성화
                upgradeCostText.text = "Max";
            }
            else
            {
                upgradeButton.interactable = true; // 업그레이드 버튼 활성화
                upgradeCostText.text = $"{costs[currentLevel]}\\"; // 업그레이드 비용 텍스트 업데이트

            }
        }
        private void OnDestroy()
        {
            PlayerPrefs.SetInt(statData.statName + "_Level", currentLevel); // 레벨 저장
            PlayerPrefs.Save(); // PlayerPrefs 저장
        }
    }
    
}