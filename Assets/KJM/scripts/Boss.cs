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
                Destroy(gameObject); // �� ���� ������Ʈ�� �����.
                Instantiate(Coin, deathPosition, Quaternion.identity);
            }
        }
    }
}
