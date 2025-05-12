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

        // �ܺο��� ���� ������ ���� �̺�Ʈ�� �޾� �ʱ�ȭ
        public void Setup(Sprite iconSprite, string nameText, string descText, Action onSelect)
        {
            weaponName.text = nameText;
            description.text = descText;

            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(() => onSelect());
        }
    }
}
