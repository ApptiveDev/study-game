using UnityEngine;

public class weaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponPrefabs; // 무기 프리팹 배열
    [SerializeField] private float spawnInterval = 2f; // 무기 소환 간격
    private float curTime = 0f; // 현재 시간
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    private void Update()
    {
        curTime += Time.deltaTime; // 현재 시간 업데이트
        if (curTime >= spawnInterval) // 소환 간격이 지나면
        {
            SpawnWeapon(); // 무기 소환
            curTime = 0f; // 현재 시간 초기화
        }
    }

    private void SpawnWeapon()
    {
        int randomIndex = Random.Range(0, weaponPrefabs.Length); // 랜덤 인덱스 선택
        Instantiate(weaponPrefabs[randomIndex], transform.parent.position, Quaternion.identity); // 무기 소환
    }
}
