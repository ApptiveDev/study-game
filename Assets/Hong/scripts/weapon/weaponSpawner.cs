using UnityEngine;
using System.Collections;
namespace AJH{
    public class WeaponSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] weaponPrefabs; // 무기 프리팹 배열
        public float spawnInterval; // 무기 소환 간격
        public float curTime = 0; // 현재 시간
        public int level = 0;
        public int count = 1;



        void Start()
        {
            StartCoroutine(SpawnWeapons()); // 무기 소환 코루틴 시작
        }

        // Update is called once per frame


        private IEnumerator SpawnWeapons()
        {
            while (true)
            {
                StartCoroutine(SpawnWeapon()); // 무기 소환
                yield return new WaitForSeconds(spawnInterval); // 소환 간격 대기
            }
        }
        private IEnumerator SpawnWeapon()
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 playerPos = GameManager.instance.player.transform.position; // 플레이어 위치 가져오기
                Instantiate(weaponPrefabs[level], playerPos, Quaternion.identity); // 무기 소환
                yield return new WaitForSeconds(0.1f); // 소환 간격 대기
            }
        }
    }

}