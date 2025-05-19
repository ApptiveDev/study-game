using UnityEngine;

namespace KJS
{
    public class PlayerExp : MonoBehaviour
    {
        private int currentExp = 0;
        private int level = 1;
        private int expToNextLevel;

        [Header("경험치 곡선")]
        [SerializeField] private int baseExpToNextLevel = 5;
        [SerializeField] private float expGrowthFactor = 1.5f;

        [Header("UI 연동")]
        [SerializeField] private WeaponUIManager weaponUIManager;

        private void Start()
        {
            expToNextLevel = baseExpToNextLevel;
        }

        public void ProcessExpPickup(Collider2D collision)
        {
            var pickup = collision.GetComponent<ExpPickup>();
            if (pickup == null) return;

            GainExp(pickup.expAmount);
            Destroy(collision.gameObject);
        }

        private void GainExp(int amount)
        {
            currentExp += amount;

            while (currentExp >= expToNextLevel)
            {
                currentExp -= expToNextLevel;
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
            expToNextLevel = Mathf.RoundToInt(baseExpToNextLevel * Mathf.Pow(expGrowthFactor, level - 1));

            Debug.Log($"레벨 업! 현재 레벨: {level}, 다음 레벨까지 필요 경험치: {expToNextLevel}");

            Time.timeScale = 0f;
            weaponUIManager?.OpenWeaponSelection();
        }
    }
}
