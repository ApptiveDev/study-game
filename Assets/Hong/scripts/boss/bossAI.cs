using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
namespace AJH
{
    public class bossAI : MonoBehaviour, IDamageable
    {
        [Header("기본 스탯")]
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;

        [Header("끌어당김 세기")]
        [SerializeField] private float pullForce = 5f;

        [Header("2페이즈 발사 패턴")]
        [SerializeField] private GameObject[] projectilePrefabs;
        [SerializeField] private float fireInterval = 4f;
        [SerializeField] private float projectileSpeed = 5f;
        public Transform Transform => transform;
        private Transform playerTransform;
        private Vector2 knockback;

        public enum BossState
        {
            Phase1,
            Phase2,
            Dead
        }


        private BossState currentState; // 현재 상태
        void Start()
        {
            currentHealth = maxHealth;
            currentState = BossState.Phase1; // 초기 상태 설정
            playerTransform = player.Instance.transform; // 플레이어의 Transform을 가져옴
            StartCoroutine(checkState());
            StartCoroutine(FireRadialProjectiles());
        }

        // Update is called once per frame

        private IEnumerator checkState()
        {
            while (true)
            {
                if (currentHealth >= 50) currentState = BossState.Phase1;
                else if (currentHealth < 50) currentState = BossState.Phase2;
                else if (currentHealth <= 0) currentState = BossState.Dead;

                yield return new WaitForSeconds(0.1f); // 0.1초마다 상태 체크
            }
        }

        void Update()
        {
            PullPlayer();
            
        }

        public void TakeDamage(float damage)
        {
            Debug.Log(currentHealth);
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                GameManager.instance.kill++; // 경험치 증가
                // Instantiate(GameManager.instance.expPrefab[expIdx], transform.position, Quaternion.identity);
                currentState = BossState.Dead; // 상태를 Dead로 변경
                Destroy(gameObject); // 적이 죽으면 오브젝트 삭제

            }
        }

        public void AddKnockback(Vector2 force)
        {
            knockback += force;
        }


        private void PullPlayer()
        {
            if (playerTransform == null) return;

            Vector2 dir = (transform.position - playerTransform.position).normalized;
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            float maxPullDistance = 10f;
            float pullRatio = Mathf.Clamp01(distance / maxPullDistance); // 거리가 가까워질수록 흡입력 작아지게 
            float adjustedForce = pullForce * pullRatio;

            playerTransform.position += (Vector3)(dir * adjustedForce * Time.deltaTime);
        }

        private IEnumerator FireRadialProjectiles()
        {
            while (true)
            {
                if (currentState == BossState.Phase2)
                {
                    FireIn8Directions();
                    yield return new WaitForSeconds(fireInterval);
                }
                else yield return null;
            }
        }

        private void FireIn8Directions()
        {
            for (int i = 0; i < 8; i++)
            {
                float angle = i * 45f; // 360도 / 8방향
                Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                GameObject proj;
                if (i % 2 == 0)
                {
                    proj = Instantiate(projectilePrefabs[0], transform.position, Quaternion.identity);
                }
                else
                {
                    proj = Instantiate(projectilePrefabs[1], transform.position, Quaternion.identity);
                }

                Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = dir * projectileSpeed;
                }
            }
        }




    
    }
    
}
