using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float damage = 3f;
    [SerializeField] private float lifeTime = 3f;
    private float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime)
        {
            Destroy(gameObject);
        }

        transform.position += transform.right * moveSpeed * Time.deltaTime;
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
}
