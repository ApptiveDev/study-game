using UnityEngine;
namespace AJH
{

    public class enemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private float spawnInterval = 2f; // 적 소환 간격
        private float curTime = 0;
        private Vector3 spawnPosition; // 적 소환 위치
        private Vector2 playerPos; // 플레이어 위치
        void Start()
        {
            foreach (GameObject enemyPrefab in enemyPrefabs)
            {
                spawnPosition = PickRandomPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }


        // Update is called once per frame
        void Update()
        {
            curTime += Time.deltaTime;
            if (curTime >= spawnInterval)
            {
                curTime = 0;
                spawnPosition = PickRandomPosition();
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            }
        }

        Vector3 PickRandomPosition()
        {
            playerPos = GameManager.instance.player.transform.position; // 플레이어 위치 가져오기
            float x = Random.Range(playerPos.x - 8f, playerPos.x + 8f); // 플레이어 위치를 기준으로 x축 랜덤 위치
            float y = Random.Range(playerPos.y - 8f, playerPos.y + 8f); // 플레이어 위치를 기준으로 y축 랜덤 위치

            return new Vector3(x, y, 0);
        }
    }

}