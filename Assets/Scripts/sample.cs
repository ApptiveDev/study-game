using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    public int spwanSec = 3;
    public int spwanNum = 3;
    [SerializeField] GameObject Spawned;
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

        Vector3 PickRandomPosition()
        {
            float x = transform.position.x + Random.Range(-3f, 3f);
            float y = transform.position.y + Random.Range(-3f, 3f);

            return new Vector3(x, y, 0);
        }

        Quaternion GetRotation(Vector3 spawnPos)//스포너 밖을 향하도록 회전
        {
            Vector3 toSpawner = transform.position - spawnPos;
            float angle = Mathf.Atan2(toSpawner.y, toSpawner.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, angle + 90);
        }
    }



    /*Color PickRandomColor()
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);

        return new Color(r, g, b);
    }*/

    /*메소드 대문자, 변수 소문자
     GameObj 띄어쓰기 x*/
}
