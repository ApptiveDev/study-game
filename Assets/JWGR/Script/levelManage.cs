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
        private Dictionary<GameObject, int> currentWeaponLevels = new Dictionary<GameObject, int>(); // 현재 무기 레벨 저장

        private void Start()
        {
            // 필요하다면 무기 리스트 초기화 코드 추가
        }

        public void OpenLevelUpPanel()
        {
            levelUpPanel.SetActive(true);
            Time.timeScale = 0f;

            weaponInUI.Clear();
            currentWeaponLevels.Clear(); // 패널 열 때마다 현재 레벨 정보 초기화

            List<int> randomIndices = Enumerable.Range(0, weaponList.Count)
                                                .OrderBy(x => Random.value)
                                                .Take(3)
                                                .ToList();

            foreach (int index in randomIndices)
            {
                GameObject selectedWeapon = weaponList[index];
                weaponInUI.Add(selectedWeapon);
                currentWeaponLevels[selectedWeapon] = selectedWeapon.GetComponent<ItemData>().weaponLevel; // 현재 레벨 저장
            }

            setUIInfo select0UI = select0.GetComponent<setUIInfo>();
            setUIInfo select1UI = select1.GetComponent<setUIInfo>();
            setUIInfo select2UI = select2.GetComponent<setUIInfo>();

            selectedButton button0 = select0.GetComponent<selectedButton>();
            selectedButton button1 = select1.GetComponent<selectedButton>();
            selectedButton button2 = select2.GetComponent<selectedButton>();

            button0.weapon = weaponInUI[0];
            button1.weapon = weaponInUI[1];
            button2.weapon = weaponInUI[2];

            ItemData itemData0 = weaponInUI[0].GetComponent<ItemData>();
            ItemData itemData1 = weaponInUI[1].GetComponent<ItemData>();
            ItemData itemData2 = weaponInUI[2].GetComponent<ItemData>();

            select0UI.SetInfo(itemData0.itemDesc, itemData0.itemName, itemData0.itemState, itemData0.itemIcon);
            select1UI.SetInfo(itemData1.itemDesc, itemData1.itemName, itemData1.itemState, itemData1.itemIcon);
            select2UI.SetInfo(itemData2.itemDesc, itemData2.itemName, itemData2.itemState, itemData2.itemIcon);
        }

        public void CloseLevelUpPanel()
        {
            levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        public void UpgradeSelectedWeapon(GameObject selectedWeapon)
        {
            if (currentWeaponLevels.ContainsKey(selectedWeapon))
            {
                ItemData itemData = selectedWeapon.GetComponent<ItemData>();
                itemData.weaponLevel = currentWeaponLevels[selectedWeapon] + 1;
                selectedWeapon.GetComponent<ItemUpgrade>().Upgrades(); // 실제 업그레이드 적용 및 저장
            }
        }
    }
}