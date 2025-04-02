using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float attackRange = 5f;
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
            Vector3 spawnPosition = transform.position;
            Vector3 direction = (nearestEnemy.position - spawnPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Instantiate(arrowPrefab, spawnPosition, Quaternion.Euler(0, 0, angle));
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
