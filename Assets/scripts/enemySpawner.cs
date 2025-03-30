using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs; 

    void Start()
    {
        // 각 적 종류마다 5마리씩 소환
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 spawnPosition = PickRandomPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 PickRandomPosition() 
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-3f, 3f);

        return new Vector3(x, y, 0);
    }
}
