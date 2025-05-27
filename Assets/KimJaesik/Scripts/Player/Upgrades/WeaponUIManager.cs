using System.Collections.Generic;
using KJS;
using UnityEngine;

public class WeaponUIManager : MonoBehaviour
{
    [Header("UI 참조")]
    [SerializeField] private GameObject weaponPanelPrefab; // 무기 선택지 프리팹 (WeaponPanel)
    [SerializeField] private GameObject panelParent;        // 카드들이 들어갈 부모 (예: Choices)
    [SerializeField] private GameObject panel;             // 전체 UI 패널 (WeaponPanel Canvas)

    private void OnEnable()
    {
        Time.timeScale = 0f; // 게임 일시정지
    }

    private void OnDisable()
    {
        Time.timeScale = 1f; // 게임 재개
        ClearPanels();
    }

    public void ShowPanels(List<WeaponData> weaponChoices)
    {
        Debug.Log($"[WeaponUIManager] 무기 선택지 {weaponChoices.Count}개 생성 시도");

        foreach (WeaponData data in weaponChoices)
        {
            GameObject cardObj = Instantiate(weaponPanelPrefab, panelParent.transform);
            Debug.Log($"[WeaponUIManager] 카드 생성됨: {data.weaponName}");

            WeaponPanel weaponPanel = cardObj.GetComponent<WeaponPanel>();
            if (weaponPanel == null)
            {
                Debug.LogError("WeaponPanel 스크립트가 프리팹에 없음!");
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

        panel.SetActive(false); // 패널 닫기 → OnDisable() 호출됨
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

