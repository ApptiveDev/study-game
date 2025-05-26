using UnityEngine;
using UnityEngine.UI;

namespace JWGR
{
    public class BuySpeed : MonoBehaviour
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
            if (Player.money >= 500)
            {
                Player.moveSpeed += 0.5f;
                Player.money -= 500;
            }
        }
    }
}