using UnityEngine;
using System.Collections;

namespace KJS
{
    public class LongRangeEnemy : MonoBehaviour
    {
        EnemyState state;
        private Transform player;

        public float speed = 12f;
        public float lifeTime = 30f;
        [SerializeField] GameObject ExpObj;

        public float attackRange = 0.01f;
        public GameObject bulletPrefab;
        [SerializeField] private float castTime = 20f;

        private void rotateToTarget(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void Start()
        {
            player = PlayerController.Instance.gameObject.transform;
            state = EnemyState.GOTOTARGET;
            StartCoroutine(FireRoutine());
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            if (player == null) return;

            CheckState();

            if (state == EnemyState.GOTOTARGET)
                Movement();
        }

        private void CheckState()
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                state = EnemyState.FIRE;
            }
            else
            {
                state = EnemyState.GOTOTARGET;
            }
        }

        private void Movement()
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
        IEnumerator FireRoutine()
        {
            while (true)
            {
                if (state == EnemyState.FIRE && player != null)
                {
                    GameObject newObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    newObj.tag = "Enemy";
                }

                yield return new WaitForSeconds(castTime);
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