using UnityEngine;
using UnityEngine.UI;

namespace JWGR
{
    public class BuyMaxHealth : MonoBehaviour
    {
        [SerializeField] Button button;

        void Start()
        {
            // Inspector 창에서 연결하지 않았다면, 코드에서 Button 컴포넌트를 찾습니다.
            if (button == null)
            {
                button = GetComponent<Button>();
            }

            // 버튼의 클릭 이벤트에 리스너 함수를 등록합니다.
            if (button != null)
            {
                button.onClick.AddListener(OnClick);
            }
        }

        public void OnClick()
        {
            if (Player.money >= 300)
            {
                Player.maxHP += 100f;
                Player.tempHP = Player.tempHP * (Player.maxHP / 100f);
                Player.money -= 300;
            }
        }
    }
}