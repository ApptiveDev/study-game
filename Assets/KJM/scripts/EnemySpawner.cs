using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KJM
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] public GameObject[] enemyObjects;
        public GameObject boss;
        float bossSpawn = 20f;
        float curTime = 0;

        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                MakeDefaultEnemy();
            }
            StartCoroutine(MakeRandomEnemy2());
            StartCoroutine(MakeBoss());
        }

        private IEnumerator MakeRandomEnemy2()
        {
            while (true)
            {
                yield return new WaitForSeconds(2.5f);
                MakeRandomEnemy();
            }
        }
        //�⺻ �� ����
        void MakeDefaultEnemy()
        {
            GameObject newEnemy = enemyObjects[0];
            Instantiate(newEnemy);
            newEnemy.transform.position = PickRandomPosition();
            newEnemy.GetComponent<SpriteRenderer>().color = PickRandomColor();
        }
        // ���Ÿ� ���� ���� �⺻ �� �������� ����
        void MakeRandomEnemy()
        {
            int randomIndex = Random.Range(0, enemyObjects.Length);
            GameObject newEnemy = enemyObjects[randomIndex];
            Instantiate(newEnemy);
            newEnemy.transform.position = PickRandomPosition();
            newEnemy.GetComponent<SpriteRenderer>().color = PickRandomColor();
        }

        private IEnumerator MakeBoss()
        {
            yield return new WaitForSeconds(bossSpawn);

            Instantiate(boss);
            boss.transform.position = PickRandomPosition();
            boss.GetComponent<SpriteRenderer>().color = PickRandomColor();
        }

        Vector3 PickRandomPosition() // ���� ��ġ ��ȯ
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);

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
