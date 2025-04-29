using System;
using UnityEngine;

public class RangedEnemy : EnemyBase
{
    [SerializeField] private GameObject arrow;
    private GameObject player;
    private float curTime = 0f;

    private void Start()
    {
        hp = 15f;
    }

    private void Update()
    {
        player = GameObject.Find("Player") ? GameObject.Find("Player") : null;
        if (player != null)
        {
            curTime += Time.deltaTime;
            if (curTime >= 2.5f)
            {
                SpawnArrow();
                curTime = 0;
            }
        }
    }

    private void SpawnArrow()
    {
        Instantiate(arrow, transform.position, Quaternion.identity);
    }
}
