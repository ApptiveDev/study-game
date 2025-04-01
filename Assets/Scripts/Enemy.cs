using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform enemyTransform;
    Vector3 moveDir;
    float moveSpeed = 1f;
    public float health;

    private void Start()
    {
        enemyTransform = GameObject.Find("Player").transform;
        health = 10;
    }

    void Update()
    {
        moveDir = enemyTransform.position - transform.position;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
