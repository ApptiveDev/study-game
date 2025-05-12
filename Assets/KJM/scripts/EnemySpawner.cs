using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KJM
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject enemyObject;

        float curTime = 0;

        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                MakeRandomEnemy();
            }
            StartCoroutine(MakeRandomEnemy2());
        }

        private IEnumerator MakeRandomEnemy2()
        {
            while (true)
            {
                yield return new WaitForSeconds(2.5f);
                MakeRandomEnemy();
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
            float x = Random.Range(-4f, 4f);
            float y = Random.Range(-4f, 4f);

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
}
