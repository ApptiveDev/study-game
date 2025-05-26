using UnityEngine;

namespace KJM
{
    public class Holes : MonoBehaviour
    {
        public float duration = 2f; //홀은 2초간 유지된다.
        [SerializeField] GameObject Coin;
        void Start()
        {
            Destroy(gameObject, duration);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            EnemyDamage enemy = collision.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                Vector3 deathPosition = enemy.EnemyPosition();
                enemy.DestroyEnemy(); // 생성된 holde 안에 들어온 적은 소멸한다.
                Instantiate(Coin, deathPosition, Quaternion.identity);
            }
        }
    }

}
