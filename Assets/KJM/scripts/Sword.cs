using UnityEngine;
//ȸ���ϸ鼭 ���ư��� ��, �˰� ���� ������ health �� ���ҵ�.
//���� ������� �ʰ� �߷��� ������ �޾� ��������.

namespace KJM
{
    public class Sword : MonoBehaviour
    {
        Rigidbody2D rb;
        float positionY = 10f;
        float positionX = 3f;
        public float damage = 10f;
        float spinSpeed = 600f;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 force = new Vector2(Random.Range(-positionX, positionX), positionY);
                rb.AddForce(force, ForceMode2D.Impulse);
                //ȸ���ӵ� ���� ����
                rb.angularVelocity = Random.Range(-spinSpeed, spinSpeed);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyDamage enemy = collision.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
