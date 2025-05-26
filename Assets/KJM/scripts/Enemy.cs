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
            Destroy(gameObject); // 적 게임 오브젝트를 지운다.
            Instantiate(Coin, deathPosition, Quaternion.identity);
        }
    }
}
