using System.Collections.Generic;
using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace KJM
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Button> choiceButtons; // 버튼 1,2,3 배열
        public static Inventory Instance { get; private set; }
        public List<string> weaponData = new List<string>();
        private GameObject isPanel;
        private GameObject loadingMessage;
        public GameObject newWeaponPrefab;
        int selectedIndexes;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            //처음에 인벤토리 페널은 off
            loadingMessage = transform.Find("textBox")?.gameObject;
            isPanel = transform.Find("InventoryPanel")?.gameObject;
            if (isPanel != null )
            {
                isPanel.SetActive(false);
            }
            isPanel = transform.Find("InventoryPanel")?.gameObject; //스크립트가 붙은 오브젝트의 자식 찾기
            if (loadingMessage != null)
            {
                loadingMessage.SetActive(false);
            }
            weaponData.Add("sword");
            weaponData.Add("arrow");
            weaponData.Add("handbomb");
            loadingMessage.transform.Find("loadingText").GetComponent<TMP_Text>().text = "렌덤 선택중...";
        }
        public IEnumerator WaitRandomSelect()
        {
            //렌덤선택 텍스트 3초간 띄우기
            Time.timeScale = 0;
            loadingMessage.SetActive(true);
            yield return new WaitForSecondsRealtime(3f);

            // 3개의 무기중 하나를 랜덤으로 선택
            selectedIndexes = Random.Range(0, weaponData.Count);
            //텍스트 업데이트
            loadingMessage.transform.Find("loadingText").GetComponent<TMP_Text>().text = weaponData[selectedIndexes];
            yield return new WaitForSecondsRealtime(2f); //2초 기다리기

            loadingMessage.gameObject.SetActive(false);
            ShowInventory();
        }

        public void RandomWeaponSelect()
        {
            StartCoroutine(WaitRandomSelect());
        }
        //인벤토리 패널에 현재 선택된 무기에 적용되는 스킬 총 3가지 선택지 중 택1
        public void ShowInventory()
        {
            Debug.Log($"버튼 갯수: {choiceButtons.Count}");
            isPanel.SetActive(true);
            for (int i = 0; i < choiceButtons.Count; i++)
            {
                int choice = i;
                var button = choiceButtons[i];
                Debug.Log($"버튼 {i} 리스너 등록");
                // 이 시점에 반드시 true가 되어 있어야 버튼 클릭이 가능해
                Debug.Log("패널 활성화 여부: " + isPanel.activeSelf);


                button.onClick.RemoveAllListeners(); // 리스너 초기화
                button.onClick.AddListener(() => UpgradeWeapon(choice)); //리스너는 한번 설정하면 버튼 클릭마다 호출됨.
            }
        }
        //선택에 따라 무기 업그레이드 하는 함수
        public void UpgradeWeapon(int choice)
        {
            Debug.Log("버튼이 클릭되었습니다!");
            Debug.Log("선택 옵션 : {choice}");
            switch (choice)
            {
                case 0:
                    changeWeapon();
                    break;
                case 1:
                    break;

                case 2:
                    break;

            }

        }
        //무기를 마법 지팡이로 교체한다.
        public void changeWeapon()
        {
            WeaponSpawner spawner = Player.Instance.GetComponent<WeaponSpawner>();
            spawner.weapons[selectedIndexes] = newWeaponPrefab;
        }
    }

}
