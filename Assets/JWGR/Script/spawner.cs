using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JWGR
{
    public class spawner : MonoBehaviour
    {
        // 원 변수를 유니티에서 볼 수 있게 직렬화한 후, 프리팹을 참조시켜 준다.
        [SerializeField] GameObject[] enemyObject;
        [SerializeField] GameObject player;
        //public List<GameObject> prefabList = new List<GameObject>();

        //float curTime = 0;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0 ; i < enemyObject.Length; i++)
                {
                    MakeRandomEnemy(i);
                }
                yield return new WaitForSeconds(3.5f);
            }
        }

        private GameObject MakeRandomEnemy(int i)
        {
            GameObject clone = Instantiate(enemyObject[i]);
            clone.transform.position = PickRandomPosition();
            // clone.GetComponent<SpriteRenderer>().color = PickRandomColor();
            clone.GetComponent<SpriteRenderer>().sortingOrder = 6;

            return clone;
        }

        private Vector3 PickRandomPosition()
        {
            float x = Random.Range(-3f, 3f);
            float y = Random.Range(-3f, 3f);

            return new Vector3(x, y, 0);
        }

        //private Color PickRandomColor()
        //{
        //    float r = Random.Range(0, 1f);
        //    float g = Random.Range(0, 1f);
        //    float b = Random.Range(0, 1f);

        //    return new Color(r, g, b);
        //}
    }
}
