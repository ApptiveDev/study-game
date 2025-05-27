using System.Collections;
using UnityEngine;

namespace KJM
{
    public class Enemy : EnemyDamage
    {
        [SerializeField]GameObject Coin;
        float moveDistance = 0.003f;
        float enemySpeed = 1f;

        private void Start()
        {
            StartCoroutine(MoveEnemy());
        }

        private IEnumerator MoveEnemy()
        {
            while (health > 0)
            {
                    Vector3 playerPosition = Player.Instance.transform.position;
                    Vector3 curPosition = transform.position;

                    transform.position = Vector3.MoveTowards(curPosition, playerPosition, enemySpeed * Time.deltaTime);
                
                yield return null;
            }
            /*MakeCoin();*/
            Vector3 deathPosition = transform.position;
            Destroy(gameObject); // �� ���� ������Ʈ�� �����.
            Instantiate(Coin, deathPosition, Quaternion.identity);
        }
    }
}
