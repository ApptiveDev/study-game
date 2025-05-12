using Unity.VisualScripting;
using UnityEngine;

namespace KJS
{
    public class Enemy : MonoBehaviour
    {
        private Transform player;

        public float speed = 12f;
        public float lifeTime = 30f;
        [SerializeField] GameObject ExpObj;

        private void rotateToTarget(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        void Start()
        {
            player = PlayerController.Instance.gameObject.transform;
            Destroy(gameObject, lifeTime);
        }

        void Update()
        {
            if (player == null) return;
            movement();
        }

        void movement()
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime; if (player == null) return;

            rotateToTarget(direction);
        }
        private void OnTriggerEnter2D(Collider2D collision) // 충돌했을 때
        {
            if (collision.CompareTag("Player"))
            {
                KJS.PlayerController target = collision.GetComponent<KJS.PlayerController>();
                if (target != null)
                {
                    target.Hit();
                }
                gameObject.SetActive(false); // 본인 오브젝트도 끈다.
            }
        }

        public void Hit()
        {
            GameObject newObj = Instantiate(ExpObj, transform.position, Quaternion.identity);
            newObj.tag = "ExpObj";
            Destroy(gameObject);
        }
    }
}