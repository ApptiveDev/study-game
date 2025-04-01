using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefab;
    private float time = 2f;
    private float enemySpawnDelay = 3f;
    

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= enemySpawnDelay)
        {
            RespawnEnemy();
            time = 0f;
        }
    }
    private void RespawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, player.transform.position + new Vector3(Random.Range(5f, -5f), Random.Range(5f, -5f)), Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().SetTarget(player);
    }
}
