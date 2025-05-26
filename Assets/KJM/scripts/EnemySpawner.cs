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
        float delay = 2f;

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
                yield return new WaitForSeconds(delay);
                MakeRandomEnemy();
            }
        }
        //기본 적 생성
        void MakeDefaultEnemy()
        {
            GameObject newEnemy = enemyObjects[0];
            Instantiate(newEnemy);
            newEnemy.transform.position = PickRandomPosition();
            newEnemy.GetComponent<SpriteRenderer>().color = PickRandomColor();
        }
        // 원거리 공격 적과 기본 적 렌덤으로 생성
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
            while (true)
            {
                yield return new WaitForSeconds(bossSpawn);
                delay -= 0.5f;
                if (delay <= 0) delay = 0.5f;
                Instantiate(boss);
                boss.transform.position = PickRandomPosition();
            }
        }

        Vector3 PickRandomPosition() // 랜덤 위치 반환
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);

            return new Vector3(x, y, 0);
        }

        Color PickRandomColor() // 랜덤 색 반환
        {
            float r = Random.Range(0, 1f);
            float g = Random.Range(0, 1f);
            float b = Random.Range(0, 1f);

            return new Color(r, g, b);
        }
    }
}
