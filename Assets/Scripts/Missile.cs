using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float initialSpeed = 8f;     // �ʱ� ���� �ӵ�
    public float homingSpeed = 5f;       // ���� �� �ӵ�
    public float homingDelay = 0.5f;     // �߻� �� ���� ���۱��� ������
    public float rotateSpeed = 200f;     // ȸ�� �ӵ�
    public float lifeTime = 5f;          // �̻��� ���� �ð� (��)

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
            // ���� Ÿ���� null�̰ų� ��Ȱ��ȭ�Ǿ����� �ٽ� Ÿ�� ã��
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
            Destroy(collision.gameObject); // �� �ı�
            Destroy(gameObject);           // �̻��ϵ� �ı�
        }
    }
}
