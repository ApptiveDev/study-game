using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float initialSpeed = 8f;     // 초기 직진 속도
    public float homingSpeed = 5f;       // 유도 시 속도
    public float homingDelay = 0.5f;     // 발사 후 유도 시작까지 딜레이
    public float rotateSpeed = 200f;     // 회전 속도
    public float lifeTime = 5f;          // 미사일 존재 시간 (초)

    private Rigidbody2D rb;
    private Transform target;
    private bool isHoming = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * initialSpeed;

        StartCoroutine(StartHomingDelay());

        FindAndSetTarget();
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (isHoming)
        {
            // 현재 타겟이 null이거나 비활성화되었으면 다시 타겟 찾기
            if (target == null || !target.gameObject.activeInHierarchy)
            {
                FindAndSetTarget();
            }

            if (target != null)
            {
                Vector2 direction = ((Vector2)target.position - rb.position).normalized;
                float rotateAmount = Vector3.Cross(direction, transform.up).z;

                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.linearVelocity = transform.up * homingSpeed;
            }
        }
    }

    private IEnumerator StartHomingDelay()
    {
        yield return new WaitForSeconds(homingDelay);
        isHoming = true;
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
            Destroy(collision.gameObject); // 적 파괴
            Destroy(gameObject);           // 미사일도 파괴
        }
    }
}
