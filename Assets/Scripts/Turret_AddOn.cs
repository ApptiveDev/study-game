using UnityEngine;

public class Turret_AddOn : MonoBehaviour
{
    private Transform enemy;

    [SerializeField] private GameObject Spawned;
    public float castTime = 0.2f;
    private float spawnTimer = 0f;

    [SerializeField] private float rotationSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        if (enemy == null)
        {
            FindNearestEnemy();
        }

        if (enemy != null)
        {
            RotateTowardsTarget(enemy.position);
            HandleSpawning();

            if (!enemy.gameObject.activeInHierarchy)
            {
                enemy = null;
            }
        }
    }

    // ���� ����� ���� ã�Ƽ� enemy�� ����
    private void FindNearestEnemy()
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

    // ��ǥ�� ���� �ε巴�� ȸ��
    private void RotateTowardsTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    // �Ѿ� ���� �ڵ鸵
    private void HandleSpawning()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= castTime)
        {
            Instantiate(Spawned, transform.position, transform.rotation);
            spawnTimer = 0f;
        }
    }
}