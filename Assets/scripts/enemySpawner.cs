using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; 
    private Vector3 spawnPosition; // 적 소환 위치
    private float curTime = 0;
    void Start()
    {
        // 각 적 종류마다 3마리씩 소환
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            for (int i = 0; i < 1; i++)
            {
                spawnPosition = PickRandomPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 1f) // 1초마다 적 소환
        {
            curTime = 0;
            spawnPosition = PickRandomPosition();
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }

    Vector3 PickRandomPosition() 
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-3f, 3f);

        return new Vector3(x, y, 0);
    }
}
