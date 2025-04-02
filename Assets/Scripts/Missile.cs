using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private GameObject leafPrefab;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float lifeTime = 3f;
    private float time = 0f;
    private Transform targetTransform;
    private Vector3 lastTargetPosition;

    public void SetTargetTransform(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime)
        {
            Destroy(gameObject);
        }
        if (targetTransform != null)
        {
            lastTargetPosition = targetTransform.position;
        }
        else if ((lastTargetPosition - transform.position).magnitude <= 0.1f)
        {
            Destroy(gameObject);
        }
        transform.position += (lastTargetPosition - transform.position).normalized * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.Damaged(damage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(leafPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        }
        Destroy(gameObject);
    }
}
