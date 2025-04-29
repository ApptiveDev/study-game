using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemy;
    
    float curTime = 0;

    private void Start()
    {
        StartCoroutine(MakeRandomEnemy2());
    }

    // private void Update()
    // {
    //     curTime += Time.deltaTime;
    //     if (curTime >= 2) 
    //     {
    //         MakeRandomEnemy();
    //         curTime = 0;
    //     }
    // }
    
    private IEnumerator MakeRandomEnemy2()
    {
        while (true)
        {
            //yield return new WaitForSeconds(2f);

            yield return new WaitForSecondsRealtime(2f);
            MakeRandomEnemy();
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