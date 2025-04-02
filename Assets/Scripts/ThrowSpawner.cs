using UnityEngine;

public class ThrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject throwPrefab;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float spawnDelay = 5f;
    private float currentDelay = 0f;

    private void Update()
    {
        currentDelay += Time.deltaTime;
        Transform nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null) return;

        float distance = Vector3.Distance(transform.position, nearestEnemy.position);
        if (currentDelay >= spawnDelay && distance <= attackRange)
        {
            Instantiate(throwPrefab, transform.position, Quaternion.identity).GetComponent<Throw>().SetTargetTransform(nearestEnemy);
            currentDelay = 0f;
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) return null;

        Transform nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance && distance <= attackRange)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }
}
