using UnityEditor.Search;
using UnityEngine;
namespace AJH{
    public class levelUp : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        RectTransform rect;
        weaponButton[] weapon;
        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            weapon = GetComponentsInChildren<weaponButton>(true);
        }
        
        public void Show()
        {
            rect.localScale = Vector3.one;
        }

        public void Hide()
        {
            rect.localScale = Vector3.zero; // UI 비활성화
        }

        public void Select(int index)
        {
            weapon[index].OnClick();
        }
    }

}
