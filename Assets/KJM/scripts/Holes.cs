using UnityEngine;

namespace KJM
{
    public class Holes : MonoBehaviour
    {
        public float duration = 2f; //Ȧ�� 2�ʰ� �����ȴ�.
        [SerializeField] GameObject Coin;
        void Start()
        {
            Destroy(gameObject, duration);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            IEnemyDamage enemy = collision.GetComponent<IEnemyDamage>();
            if (enemy != null)
            {
                Vector3 deathPosition = enemy.EnemyPosition();
                enemy.DestroyEnemy(); // ������ holde �ȿ� ���� ���� �Ҹ��Ѵ�.
                Instantiate(Coin, deathPosition, Quaternion.identity);
            }
        }
    }

}
