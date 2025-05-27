using System.Collections.Generic;
using KJS;
using UnityEngine;

public class WeaponUIManager : MonoBehaviour
{
    [Header("UI ����")]
    [SerializeField] private GameObject weaponPanelPrefab; // ���� ������ ������ (WeaponPanel)
    [SerializeField] private GameObject panelParent;        // ī����� �� �θ� (��: Choices)
    [SerializeField] private GameObject panel;             // ��ü UI �г� (WeaponPanel Canvas)

    private void OnEnable()
    {
        Time.timeScale = 0f; // ���� �Ͻ�����
    }

    private void OnDisable()
    {
        Time.timeScale = 1f; // ���� �簳
        ClearPanels();
    }

    public void ShowPanels(List<WeaponData> weaponChoices)
    {
        Debug.Log($"[WeaponUIManager] ���� ������ {weaponChoices.Count}�� ���� �õ�");

        foreach (WeaponData data in weaponChoices)
        {
            GameObject cardObj = Instantiate(weaponPanelPrefab, panelParent.transform);
            Debug.Log($"[WeaponUIManager] ī�� ������: {data.weaponName}");

            WeaponPanel weaponPanel = cardObj.GetComponent<WeaponPanel>();
            if (weaponPanel == null)
            {
                Debug.LogError("WeaponPanel ��ũ��Ʈ�� �����տ� ����!");
            }

            weaponPanel.Setup(
                data.icon,
                data.weaponName,
                data.description,
                () => OnSelectWeapon(data)
            );
        }

        panel.SetActive(true);
    }

    private void OnSelectWeapon(WeaponData selected)
    {
        selected.ActivateWeapon();
        selected.UpgradeWeapon();

        panel.SetActive(false); // �г� �ݱ� �� OnDisable() ȣ���
    }

    private void ClearPanels()
    {
        foreach (Transform child in panelParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void OpenWeaponSelection()
    {
        List<WeaponData> choices = WeaponUpgradeManager.Instance.GetRandomWeapons(3);

        panel.SetActive(true);
        ShowPanels(choices);
    }
}

