using JWGR;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace JWGR
{
    public class selectedButton : MonoBehaviour
    {
        [SerializeField] Button button; // Inspector 창에서 버튼을 연결하거나, GetComponent로 찾을 수 있습니다.
        public GameObject weapon;
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
            Time.timeScale = 1.0f;
            ItemUpgrade itemUpgrade = weapon.GetComponent<ItemUpgrade>();
            if (itemUpgrade != null)
            {
                itemUpgrade.Upgrades();
            }
            levelManage.instance.GetComponent<levelManage>().CloseLevelUpPanel();
        }
    }
}