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
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.health -= damage * Time.deltaTime;
            }
        }
    }

}