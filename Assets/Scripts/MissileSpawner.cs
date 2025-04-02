using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float attackRange = 8f;
    [SerializeField] private float spawnDelay = 0.5f;
    private float currentDelay = 0f;

    private void Update()
    {
        currentDelay += Time.deltaTime;
        Transform nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null) return;

        float distance = Vector3.Distance(transform.position, nearestEnemy.position);
        if (currentDelay >= spawnDelay && distance <= attackRange)
        {
            Instantiate(missilePrefab, transform.position, Quaternion.identity).GetComponent<Missile>().SetTargetTransform(nearestEnemy);
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
