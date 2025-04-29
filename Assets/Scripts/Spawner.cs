using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemy;
    
    float curTime = 0;
    
    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 2) 
        {
            MakeRandomEnemy();
            curTime = 0;
        }
    }

    void MakeRandomEnemy()
    {
        int ran =  Random.Range(0, enemy.Count);
        Instantiate(enemy[ran], PickRandomPosition(),  Quaternion.identity);
    }

    Vector3 PickRandomPosition()
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-3f, 3f);

        return new Vector3(x, y, 0);
    }
}