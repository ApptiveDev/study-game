using System.Collections;
using UnityEngine;

namespace KJS
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 4f;
        public float lifeTime = 2f;

        void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        void Update()
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                KJS.Enemy enemy = collision.GetComponent<KJS.Enemy>();
                if (enemy != null)
                {
                    enemy.Hit();
                }
                Destroy(gameObject);
            }
        }
    }
}
