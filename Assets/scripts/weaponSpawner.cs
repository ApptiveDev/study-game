using UnityEngine;
using System.Collections;
namespace AJH{
    public class WeaponSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] weaponPrefabs; // 무기 프리팹 배열
        private float spawnInterval = 1.3f; // 무기 소환 간격
        private float curTime = 0; // 현재 시간



        void Start()
        {
            StartCoroutine(SpawnWeapons()); // 무기 소환 코루틴 시작
        }

        // Update is called once per frame


        private IEnumerator SpawnWeapons()
        {
            while (true)
            {
                SpawnWeapon(); // 무기 소환
                yield return new WaitForSeconds(spawnInterval); // 소환 간격 대기
            }
        }
        void SpawnWeapon()
        {
            Vector2 playerPos = GameManager.instance.player.transform.position; // 플레이어 위치 가져오기
                                                                                // 랜덤 인덱스 선택
            Instantiate(weaponPrefabs[0], playerPos, Quaternion.identity); // 무기 소환
        }
    }

}