using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefab;
    private float time = 2f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f)
        {
            RespawnEnemy();
            time = 0f;
        }
    }
    private void RespawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = player.transform.position + new Vector3(Random.Range(5f, -5f), Random.Range(5f, -5f));
        enemy.GetComponent<EnemyMovement>().SetTarget(player);
    }
}
