using UnityEngine;
//회전하면서 날아가는 검, 검과 닿은 적들의 health 가 감소됨.
//검은 사라지지 않고 중력의 영향을 받아 떨어진다.

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
                //회전속도 렌덤 설정
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
