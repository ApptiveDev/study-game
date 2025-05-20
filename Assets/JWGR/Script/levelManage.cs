using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine.Scripting;
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
        [SerializeField] List<GameObject> weaponList = new List<GameObject>();
        [SerializeField] List<GameObject> weaponInUI = new List<GameObject>();
        [SerializeField] private string[] weaponTags = { "weapon", "piercingWeapon" };

        private void Start()
        {
            //weaponList.Clear();  // 혹시 에디터에서 미리 넣어놨다면 초기화

            //foreach (string tag in weaponTags)
            //{
            //    GameObject[] foundWeapons = GameObject.FindGameObjectsWithTag(tag);
            //    weaponList.AddRange(foundWeapons);
            //}
        }

        public void OpenLevelUpPanel()
        {
            levelUpPanel.SetActive(true);
            Time.timeScale = 0f;

            weaponInUI.Clear(); // 매번 초기화

            List<int> randomIndices = Enumerable.Range(0, weaponList.Count)
                                                .OrderBy(x => Random.value)
                                                .Take(3)
                                                .ToList();

            foreach (int index in randomIndices)
            {
                weaponInUI.Add(weaponList[index]); // 뽑은 인덱스 사용
            }

            setUIInfo select0UI = select0.GetComponent<setUIInfo>();
            setUIInfo select1UI = select1.GetComponent<setUIInfo>();
            setUIInfo select2UI = select2.GetComponent<setUIInfo>();

            select0.GetComponent<selectedButton>().weapon = weaponInUI[0];
            select1.GetComponent<selectedButton>().weapon = weaponInUI[1];
            select2.GetComponent<selectedButton>().weapon = weaponInUI[2];

            ItemData itemData0 = weaponInUI[0].GetComponent<ItemData>();
            ItemData itemData1 = weaponInUI[1].GetComponent<ItemData>();
            ItemData itemData2 = weaponInUI[2].GetComponent<ItemData>();

            weaponInUI[0].GetComponent<ItemUpgrade>().StartSet();
            weaponInUI[1].GetComponent<ItemUpgrade>().StartSet();
            weaponInUI[2].GetComponent<ItemUpgrade>().StartSet();

            // ItemData의 정보를 SetInfo 함수의 인수로 전달합니다.
            select0UI.SetInfo(itemData0.itemDesc, itemData0.itemName, itemData0.itemState, itemData0.itemIcon);
            select1UI.SetInfo(itemData1.itemDesc, itemData1.itemName, itemData1.itemState, itemData1.itemIcon);
            select2UI.SetInfo(itemData2.itemDesc, itemData2.itemName, itemData2.itemState, itemData2.itemIcon);            
        }
        
        public void CloseLevelUpPanel()
        {
            levelUpPanel.SetActive(false);
        }
    }
}