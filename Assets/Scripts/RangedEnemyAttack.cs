using System;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
    private GameObject player;
    private float damage = 2f;
    private float speed = 4.5f;
    private Vector3 moveDirection;
    private float curTime = 0f;

    private void Start()
    {
        player = GameObject.Find("Player") ? GameObject.Find("Player") : null;
        if (player != null)
        {
            RotateToPlayer();
            moveDirection = (player.transform.position -  transform.position).normalized;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        MoveToPlayer();
        curTime +=  Time.deltaTime;
        if (curTime >= 5f)
            Destroy(gameObject);
    }

    private void RotateToPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }

    private void MoveToPlayer()
    {
        transform.position += moveDirection *  speed *  Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Player>().hp -= damage;
            Destroy(gameObject);
        }
    }
}
