using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpawnDelay = 3f;
    private float time = 2f;

    public void Update()
    {
        time += Time.deltaTime;
        if (time >= enemySpawnDelay)
        {
            RespawnEnemy();
            time = 0f;
        }
    }

    private void RespawnEnemyNearTarget()
    {
        GameObject enemy = Instantiate(enemyPrefab, player.transform.position + new Vector3(Random.Range(5f, -5f), Random.Range(5f, -5f)), Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().SetTarget(player);
    }

    private void RespawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().SetTarget(player);
    }
}
