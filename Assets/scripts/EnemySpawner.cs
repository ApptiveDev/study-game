using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;

    float curTime = 0;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            MakeRandomEnemy();
        }
    }
    //2�ʸ��� ���� �����
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

        enemyObject.transform.position = PickRandomPosition();
        enemyObject.GetComponent<SpriteRenderer>().color = PickRandomColor();
    }

    Vector3 PickRandomPosition() // ���� ��ġ ��ȯ
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-3f, 3f);

        return new Vector3(x, y, 0);
    }

    Color PickRandomColor() // ���� �� ��ȯ
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);

        return new Color(r, g, b);
    }
}