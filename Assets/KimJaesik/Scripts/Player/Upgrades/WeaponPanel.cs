using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace KJS
{
    public class WeaponPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI weaponName;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Button selectButton;

        // 외부에서 무기 정보와 선택 이벤트를 받아 초기화
        public void Setup(Sprite iconSprite, string nameText, string descText, Action onSelect)
        {
            weaponName.text = nameText;
            description.text = descText;

            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(() => onSelect());
        }
    }
}
