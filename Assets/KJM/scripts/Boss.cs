using System.Collections;
using UnityEngine;

namespace KJM
{
    public class Boss : EnemyDamage
    {
        [SerializeField] GameObject Coin;

        private void Update()
        {
            if (health <= 0)
            {
                Vector3 deathPosition = transform.position;
                Destroy(gameObject); // 적 게임 오브젝트를 지운다.
                Instantiate(Coin, deathPosition, Quaternion.identity);
            }
        }
    }
}
