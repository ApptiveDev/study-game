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
        [SerializeField] private List<Button> choiceButtons; // ��ư 1,2,3 �迭
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
            //ó���� �κ��丮 ����� off
            loadingMessage = transform.Find("textBox")?.gameObject;
            isPanel = transform.Find("InventoryPanel")?.gameObject;
            if (isPanel != null )
            {
                isPanel.SetActive(false);
            }
            isPanel = transform.Find("InventoryPanel")?.gameObject; //��ũ��Ʈ�� ���� ������Ʈ�� �ڽ� ã��
            if (loadingMessage != null)
            {
                loadingMessage.SetActive(false);
            }
            weaponData.Add("sword");
            weaponData.Add("arrow");
            weaponData.Add("handbomb");
            loadingMessage.transform.Find("loadingText").GetComponent<TMP_Text>().text = "���� ������...";
        }
        public IEnumerator WaitRandomSelect()
        {
            //�������� �ؽ�Ʈ 3�ʰ� ����
            Time.timeScale = 0;
            loadingMessage.SetActive(true);
            yield return new WaitForSecondsRealtime(3f);

            // 3���� ������ �ϳ��� �������� ����
            selectedIndexes = Random.Range(0, weaponData.Count);
            //�ؽ�Ʈ ������Ʈ
            loadingMessage.transform.Find("loadingText").GetComponent<TMP_Text>().text = weaponData[selectedIndexes];
            yield return new WaitForSecondsRealtime(2f); //2�� ��ٸ���

            loadingMessage.gameObject.SetActive(false);
            ShowInventory();
        }

        public void RandomWeaponSelect()
        {
            StartCoroutine(WaitRandomSelect());
        }
        //�κ��丮 �гο� ���� ���õ� ���⿡ ����Ǵ� ��ų �� 3���� ������ �� ��1
        public void ShowInventory()
        {
            Debug.Log($"��ư ����: {choiceButtons.Count}");
            isPanel.SetActive(true);
            for (int i = 0; i < choiceButtons.Count; i++)
            {
                int choice = i;
                var button = choiceButtons[i];
                Debug.Log($"��ư {i} ������ ���");
                // �� ������ �ݵ�� true�� �Ǿ� �־�� ��ư Ŭ���� ������
                Debug.Log("�г� Ȱ��ȭ ����: " + isPanel.activeSelf);


                button.onClick.RemoveAllListeners(); // ������ �ʱ�ȭ
                button.onClick.AddListener(() => UpgradeWeapon(choice)); //�����ʴ� �ѹ� �����ϸ� ��ư Ŭ������ ȣ���.
            }
        }
        //���ÿ� ���� ���� ���׷��̵� �ϴ� �Լ�
        public void UpgradeWeapon(int choice)
        {
            Debug.Log("��ư�� Ŭ���Ǿ����ϴ�!");
            Debug.Log("���� �ɼ� : {choice}");
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
        //���⸦ ���� �����̷� ��ü�Ѵ�.
        public void changeWeapon()
        {
            WeaponSpawner spawner = Player.Instance.GetComponent<WeaponSpawner>();
            spawner.weapons[selectedIndexes] = newWeaponPrefab;
        }
    }

}
