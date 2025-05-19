using System.Collections;
using UnityEngine;

namespace KJS
{
    public class BulletEnemy : MonoBehaviour
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
            if (collision.CompareTag("Player"))
            {
                KJS.PlayerController target = collision.GetComponent<KJS.PlayerController>();
                if (target != null)
                {
                    target.Hit();
                }
                Destroy(gameObject);
            }
        }
    }
}
