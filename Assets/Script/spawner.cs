using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // 원 변수를 유니티에서 볼 수 있게 직렬화한 후, 프리팹을 참조시켜 준다.
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject player;
    public List<GameObject> prefabList = new List<GameObject>();

    float curTime = 0;

    // 생명주기 프레임당 실행.
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 2)
        {
            MakeRandomEnemy();
            curTime = 0;
        }

    }

    GameObject MakeRandomEnemy()
    {
        GameObject clone = Instantiate(enemyObject);
        enemyObject.transform.position = PickRandomPosition();
        enemyObject.GetComponent<SpriteRenderer>().color = PickRandomColor();
        enemyObject.GetComponent<SpriteRenderer>().sortingOrder = 6;

        return clone;
    }

    Vector3 PickRandomPosition()
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-3f, 3f);

        return new Vector3(x, y, 0);
    }

    Color PickRandomColor()
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);

        return new Color(r, g, b);
    }
}
