using UnityEngine;
using System.Collections;

namespace KJS
{
    public class Turret_AddOn : MonoBehaviour
    {
        private Transform enemy;

        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] public float castTime = 0.2f;
        [SerializeField] private float rotationSpeed = 5f;

        void Start()
        {
            StartCoroutine(FindTargetRoutine());
            StartCoroutine(FireRoutine());
        }

        void Update()
        {
            if (enemy != null)
            {
                RotateTowardsTarget(enemy.position);

                // 적이 죽었거나 비활성화되었으면 타겟 해제
                if (!enemy.gameObject.activeInHierarchy)
                {
                    enemy = null;
                }
            }
        }

        IEnumerator FindTargetRoutine()
        {
            while (true)
            {
                if (enemy == null)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    float closestDistance = Mathf.Infinity;
                    GameObject closestEnemy = null;

                    foreach (GameObject e in enemies)
                    {
                        float distance = Vector3.Distance(transform.position, e.transform.position);
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestEnemy = e;
                        }
                    }

                    if (closestEnemy != null)
                    {
                        enemy = closestEnemy.transform;
                    }
                }

                yield return new WaitForSeconds(0.2f); // 타겟 재탐색 주기
            }
        }

        IEnumerator FireRoutine()
        {
            while (true)
            {
                if (enemy != null)
                {
                    Instantiate(bulletPrefab, transform.position, transform.rotation);
                }

                yield return new WaitForSeconds(castTime);
            }
        }

        void RotateTowardsTarget(Vector3 targetPosition)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}

