using System.Collections;
using UnityEngine;

namespace KJM
{
    public class Boss : MonoBehaviour, IEnemyDamage
    {
        [SerializeField] GameObject Coin;
        public float health = 200f;

        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log($"Boss Health : {health}");
        }
        public void TakeTimeDamage(float damage)
        {
            health -= damage * Time.deltaTime;
            Debug.Log($"Boss Health : {health}");
        }
        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        public Vector3 EnemyPosition()
        {
            return transform.position;
        }
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
