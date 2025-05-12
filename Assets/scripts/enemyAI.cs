using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace AJH{
    public class enemyAI : MonoBehaviour
    {
        [Header("추격 속도")]
        public float moveSpeed = 2f;
        [Header("체력")]
        public float health = 5f;
        [Header("넉백 감쇠 속도")]
        [SerializeField] private float knockbackDecay = 5f;
        [Header("몹 데미지")]
        [SerializeField] private float damage = 1f;
        [SerializeField] private int expIdx;
        

        private Transform playerTransform;
        private SpriteRenderer spriteRenderer;
        private Vector2 knockback;   // 현재 남아 있는 넉백 벡터

        void Start()
        {
            //싱글톤으로 찾기

            if (player.Instance != null)
                playerTransform = player.Instance.transform; // 플레이어의 Transform을 가져옴

            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            if (playerTransform == null) return;

            // 1) 플레이어를 향한 추격 벡터
            Vector2 chaseDir = (playerTransform.position - transform.position).normalized;

            // 2) 최종 이동 벡터 = 추격 + 넉백
            Vector2 velocity = chaseDir * moveSpeed + knockback;

            // 3) 이동
            transform.position += (Vector3)(velocity * Time.deltaTime);

            // 4) 넉백을 서서히 감쇠
            knockback = Vector2.MoveTowards(knockback, Vector2.zero, knockbackDecay * Time.deltaTime);

            // 5) 스프라이트 좌우 반전
            if (velocity.x < 0) spriteRenderer.flipX = true;
            else if (velocity.x > 0) spriteRenderer.flipX = false;
        }

        public void AddKnockback(Vector2 force)
        {
            knockback += force;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                GameManager.instance.kill++; // 경험치 증가
                Instantiate(GameManager.instance.expPrefab[expIdx], transform.position, Quaternion.identity);
                Destroy(gameObject); // 적이 죽으면 오브젝트 삭제

            }
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) {
                GameManager.instance.GetWeight(damage); // 플레이어에게 데미지
            }
        }
    }
}
