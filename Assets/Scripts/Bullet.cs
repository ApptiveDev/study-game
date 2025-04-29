using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 1f;
    private float curTime = 0f;

    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 5f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBase enemy = other.gameObject.GetComponent<EnemyBase>();
            enemy.hp -= damage;
            if (enemy.hp <= 0)
                Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
    }
}
