using UnityEngine;
using System.Collections;

namespace KJS
{
    public class Missile : MonoBehaviour
    {
        public float initialSpeed = 8f;
        public float homingSpeed = 5f;
        public float homingDelay = 0.5f;
        public float rotateSpeed = 200f;
        public float detectRadius = 3f;
        public GameObject bulletPrefab;
        public float lifeTime = 5f;

        private Rigidbody2D rb;
        private Transform target;
        private bool isHoming = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * initialSpeed;

            StartCoroutine(StartHomingDelay());
            StartCoroutine(HomingRoutine());

            FindAndSetTarget();
            Destroy(gameObject, lifeTime);
        }

        IEnumerator StartHomingDelay()
        {
            yield return new WaitForSeconds(homingDelay);
            isHoming = true;
        }

        IEnumerator HomingRoutine()
        {
            while (true)
            {
                if (isHoming && target != null)
                {
                    Vector2 direction = ((Vector2)target.position - rb.position).normalized;
                    float rotateAmount = Vector3.Cross(direction, transform.up).z;

                    rb.angularVelocity = -rotateAmount * rotateSpeed;
                    rb.linearVelocity = transform.up * homingSpeed;

                    // 유도 중 적과의 거리 측정
                    float distance = Vector2.Distance(transform.position, target.position);
                    if (distance <= detectRadius)
                    {
                        FireBullets();
                        Destroy(gameObject);
                        yield break;
                    }
                }
                else
                {
                    FindAndSetTarget();
                }

                yield return new WaitForSeconds(0.1f); // 유도 판단 주기
            }
        }

        private void FireBullets()
        {
            float[] angles = { -30f, -15f, 0f, 15f, 30f };

            foreach (float angle in angles)
            {
                Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, angle);
                Instantiate(bulletPrefab, transform.position, rotation);
            }
        }

        private void FindAndSetTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                target = null;
                return;
            }

            Transform closest = enemies[0].transform;
            float closestDistance = Vector2.Distance(transform.position, closest.position);

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closest = enemy.transform;
                    closestDistance = distance;
                }
            }

            target = closest;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                KJS.Enemy enemy = collision.GetComponent<KJS.Enemy>();
                if (enemy != null)
                {
                    enemy.Hit();
                }
                Destroy(gameObject);
            }
        }
    }
}
