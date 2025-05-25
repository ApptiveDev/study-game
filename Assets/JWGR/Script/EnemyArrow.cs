using UnityEngine;

namespace JWGR
{
    public class EnemyArrow : MonoBehaviour
    {
        public GameObject enemy;
        public GameObject player;
        private Vector3 moveDir; // 이동 방향 벡터
        public float moveSpeed = 3f; // 화살의 이동 속도

        private void Start()
        {
            GetComponent<SpriteRenderer>().sortingOrder = 7;
            player = GameObject.Find("Player");
            moveDir = (player.transform.position - transform.position).normalized; // 초기 이동 방향 벡터를 계산하고 정규화합니다.

        }

        private void Update()
        {
            // 타겟 방향으로 이동
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            // 오브젝트가 목표 적을 바라보도록 회전
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // 이미지가 위를 향하고 있으므로 -90도 보정

            // 일정 거리 이상 이동하면 화살을 제거 (선택 사항)
            float distanceToStart = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToStart > 20f) // 예시 거리: 20
            {
                Destroy(gameObject);
            }
        }
    }
}