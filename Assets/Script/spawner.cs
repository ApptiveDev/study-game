using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // 원 변수를 유니티에서 볼 수 있게 직렬화한 후, 프리팹을 참조시켜 준다.
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject player;
    GameObject _clone;
    List<GameObject> prefabList = new List<GameObject>();

    public float speed = 1f;
    float curTime = 0;

    void Start()
    {
        
    }

    // 프레임당 실행.
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 2)
        {
            GameObject _clone = MakeRandomEnemy();
            prefabList.Add(_clone);
            curTime = 0;
        }

        if (prefabList.Count != 0)
        {
            for (int i = 0; i < prefabList.Count; i++)
            {
                // null 체크
                if (prefabList[i] == null) continue;

                Vector3 dirVector = DirToObect(prefabList[i], player);
                prefabList[i].transform.position += (-dirVector.normalized * speed * Time.deltaTime);
            }
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

    Vector3 DirToObect(GameObject toObject, GameObject player)
    {
        Vector3 direction = new Vector3(
                toObject.transform.position.x - player.transform.position.x,
                toObject.transform.position.y - player.transform.position.y, 0);
        return direction;
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
