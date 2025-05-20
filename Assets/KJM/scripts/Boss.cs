using System.Collections;
using UnityEngine;

namespace KJM
{
    public class Boss : MonoBehaviour, EnemyDamage
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
    }
}
