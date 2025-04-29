using System;
using UnityEngine;

public class Enemy : EnemyBase
{
    private GameObject player;
    private float speed = 2f;
    private float damage = 1f;

    private void Start()
    {
        hp = 10f;
    }

    private void Update()
    {
        player = Player.Instance.gameObject;
        if (player != null)
        {
            transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().hp -= damage;
            Destroy(gameObject);
        }
    }
}
