using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    public int spwanSec = 3;
    public int spwanNum = 3;
    [SerializeField] GameObject Spawned;

    private Vector3 PickRandomPosition()
    {
        float x = transform.position.x + Random.Range(-3f, 3f);
        float y = transform.position.y + Random.Range(-3f, 3f);

        return new Vector3(x, y, 0);
    }

    private Quaternion GetRotation(Vector3 spawnPos)//스포너 밖을 향하도록 회전
    {
        Vector3 toSpawner = transform.position - spawnPos;
        float angle = Mathf.Atan2(toSpawner.y, toSpawner.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, angle + 90);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float curTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= spwanSec)
        {
            for (int i = 0; i < spwanNum; i++)
            {
                GameObject newObj = Instantiate(Spawned);

                Vector3 spawnPos = PickRandomPosition();
                newObj.transform.position = spawnPos;
                newObj.transform.rotation = GetRotation(spawnPos);
            }
            curTime = 0;
        }
    }
}