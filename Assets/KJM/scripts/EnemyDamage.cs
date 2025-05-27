using UnityEngine;

namespace KJM
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] public float health = 100f;
        public void TakeDamage(float damage)
        {
            health -= damage;
        }
        public void TakeTimeDamage(float damage)
        {
            health -= damage * Time.deltaTime;
        }
        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }
        public Vector3 EnemyPosition()
        {
            return transform.position;
        }
    }

}