using UnityEngine;

namespace KJM
{
    public class FireZone : MonoBehaviour
    {
        public float damage = 10f;
        public float duration = 5f;

        void Start()
        {
            Destroy(gameObject, duration);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            EnemyDamage enemy = collision.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                enemy.TakeTimeDamage(damage);
            }
        }
    }

}