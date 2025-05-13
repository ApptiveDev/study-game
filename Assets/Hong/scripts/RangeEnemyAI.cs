using System.Collections;
using UnityEngine;
namespace AJH{
    public class RangeEnemyAI : MonoBehaviour
    {
        public enum EnemyState 
        {
            Chase,
            Attack,
            Dead
        }

        [Header("추격 속도")]
        public float moveSpeed = 1f;
        [Header("체력")]
        public float health = 5f;
        [Header("넉백 감쇠 속도")]
        [SerializeField] private float knockbackDecay = 5f;
        [Header("몹 데미지")]
        [SerializeField] private float damage = 3f;
        [SerializeField] private int expIdx;
        [SerializeField] private float attackRange = 4f; // 공격 범위
        

        private Transform playerTransform;
        private SpriteRenderer spriteRenderer;
        private Vector2 knockback;   // 현재 남아 있는 넉백 벡터

        private EnemyState currentState; // 현재 상태
        // Update is called once per frame
        void Start()
        {
            if (player.Instance != null)
                playerTransform = player.Instance.transform; // 플레이어의 Transform을 가져옴

            spriteRenderer = GetComponent<SpriteRenderer>();
            currentState = EnemyState.Chase;
            StartCoroutine(checkState()); // 상태 체크 코루틴 시작
        }


        void Update()
        {
            if (currentState == EnemyState.Chase) {
                ChasePlayer();
            }
            else if (currentState == EnemyState.Attack) {
                AttackPlayer();
            }
        }

        private IEnumerator checkState() {
            while(true) {

                if (Vector2.Distance(playerTransform.position, transform.position) < attackRange )
                {
                    currentState = EnemyState.Attack;
                }
                else
                {
                    currentState = EnemyState.Chase;
                }
                yield return new WaitForSeconds(0.1f); // 0.1초마다 상태 체크
            }
        }


        void ChasePlayer() {
            Vector2 chaseDir = (playerTransform.position - transform.position).normalized;
            Vector2 velocity = chaseDir * moveSpeed + knockback;
            transform.position += (Vector3)(velocity * Time.deltaTime);
            knockback = Vector2.MoveTowards(knockback, Vector2.zero, knockbackDecay * Time.deltaTime);

            if (velocity.x < 0) spriteRenderer.flipX = true;
            else if (velocity.x > 0) spriteRenderer.flipX = false;
        }


        void AttackPlayer() {

        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                GameManager.instance.kill++; // 경험치 증가
                Instantiate(GameManager.instance.expPrefab[expIdx], transform.position, Quaternion.identity);
                currentState = EnemyState.Dead; // 상태를 Dead로 변경
                Destroy(gameObject); // 적이 죽으면 오브젝트 삭제

            }
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.GetWeight(damage); // 플레이어에게 데미지
            }
        }
    }

}
