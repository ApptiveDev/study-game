using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject player;

    float curTime = 0;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            MakeRandomEnemy();
        }
    }
    //2초마다 적을 만든다
    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 2f)
        {
            MakeRandomEnemy();
            curTime = 0;
        }
    }

    void MakeRandomEnemy()
    {
        GameObject newEnemy = Instantiate(enemyObject);
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        enemyObject.transform.position = PickRandomPosition();
        enemyObject.GetComponent<SpriteRenderer>().color = PickRandomColor();
    }

    Vector3 PickRandomPosition() // 랜덤 위치 반환
    {
        float x = Random.Range(-4f, 4f);
        float y = Random.Range(-4f, 4f);

        return new Vector3(x, y, 0);
    }

    Color PickRandomColor() // 랜덤 색 반환
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);

        return new Color(r, g, b);
    }
}