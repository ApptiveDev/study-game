// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
// namespace AJH
// {
//     public class BossHealthUI : MonoBehaviour
//     {
//         [SerializeField] private Slider slider;
//         private bossAI boss;
//         private TextMeshProUGUI bossHealthText;

//         public void SetBoss(bossAI bossRef)
//         {
//             Debug.Log("SetBoss 호출됨, 보스 체력바 켜짐");
//             bossHealthText = GetComponentInChildren<TextMeshProUGUI>();
//             boss = bossRef;
//             slider.maxValue = boss.maxHealth;
//             bossHealthText.text = "짭조름한 감튀 ";
//             gameObject.SetActive(true); // UI 보이게 하기
//         }

//         public void Hide()
//         {
//             gameObject.SetActive(false); // UI 감추기
//         }

//         void Update()
//         {
//             if (boss s== null) return;

//             slider.value = boss.currentHealth;
//             bossHealthText.text = "짭조름한 감튀 " + boss.currentHealth + "/" + boss.maxHealth;
//         }
        
//         public void setBossHealth()
//         {
//             if (slider != null)
//             {
//                 slider.value = boss.currentHealth;
//             }
//         }
//     }
    
// }
