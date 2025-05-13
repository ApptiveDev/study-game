using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace JWGR
{
    public class levelManage : MonoBehaviour
    {
        [SerializeField] GameObject levelUpPanel;
        [SerializeField] Button select0;
        [SerializeField] Button select1;
        [SerializeField] Button select2;
        [SerializeField] GameObject[] weaponList;
        private GameObject[] weaponInUI = new GameObject[3];

        void Start()
        {
            float Level = Player.Instance.Level;
        }

        void OpenLevelUpPanel()
        {
            for (int i = 0; i < 3; i++)
            {
                int j = Random.Range(0, weaponList.Length);
                weaponInUI[j] = weaponList[j];
            }

            setUIInfo select0UI = select0.GetComponent<setUIInfo>();
            setUIInfo select1UI = select1.GetComponent<setUIInfo>();
            setUIInfo select2UI = select2.GetComponent<setUIInfo>();

            ItemData itemData0 = weaponInUI[0].GetComponent<ItemData>();
            ItemData itemData1 = weaponInUI[0].GetComponent<ItemData>();
            ItemData itemData2 = weaponInUI[0].GetComponent<ItemData>();
            
            // ItemData의 정보를 SetInfo 함수의 인수로 전달합니다.
            select0UI.SetInfo(itemData0.itemDesc, itemData0.itemName, itemData0.itemState, itemData0.itemIcon);
            select1UI.SetInfo(itemData1.itemDesc, itemData1.itemName, itemData1.itemState, itemData1.itemIcon);
            select2UI.SetInfo(itemData2.itemDesc, itemData2.itemName, itemData2.itemState, itemData2.itemIcon);

            levelUpPanel.SetActive(true);
        }
        
        void CloseLevelUpPanel()
        {
            levelUpPanel.SetActive(false);
        }
    }
}