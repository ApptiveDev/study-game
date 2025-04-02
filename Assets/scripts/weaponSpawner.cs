using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponPrefabs; // 무기 프리팹 배열
    private float spawnInterval = 1.3f; // 무기 소환 간격
    private float curTime = 0; // 현재 시간
    
    
    
 

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime; // 현재 시간 업데이트
        if (curTime >= spawnInterval) // 소환 간격이 되었을 때
        {
            curTime = 0; // 현재 시간 초기화
            SpawnWeapon(); // 무기 소환
        }
    }

    void SpawnWeapon()
    {
        Vector2 playerPos = GameManager.instance.player.transform.position; // 플레이어 위치 가져오기
         // 랜덤 인덱스 선택
        Instantiate(weaponPrefabs[0], playerPos, Quaternion.identity); // 무기 소환
    }
}
