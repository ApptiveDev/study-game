using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace JWGR
{
    public class arrow : MonoBehaviour
    {
        private Transform target; // 타겟의 트랜스폼
        public GameObject player;
        private Vector3 moveDir; // 이동 방향 벡터
        public float moveSpeed = 3f; // 화살의 이동 속도

        private void Start()
        {
            GetComponent<SpriteRenderer>().sortingOrder = 7;
            player = GameObject.Find("Player");
            transform.position = player.transform.position;
            target = FindClosestEnemy(); // 가장 가까운 적을 찾습니다.

            if (target != null)
            {
                moveDir = (target.position - transform.position).normalized; // 초기 이동 방향 벡터를 계산하고 정규화합니다.
            }
            else
            {
                // 적이 없다면 즉시 화살을 제거하거나 다른 동작을 수행할 수 있습니다.
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (target == null) // 타겟이 없다면, 화살을 지운다.
            {
                Destroy(gameObject);
                return; // 더 이상 업데이트할 내용이 없으므로 함수를 종료합니다.
            }

            // 타겟 방향으로 이동
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            // 오브젝트가 목표 적을 바라보도록 회전
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // 이미지가 위를 향하고 있으므로 -90도 보정

            // 일정 거리 이상 이동하면 화살을 제거 (선택 사항)
            float distanceToStart = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToStart > 20f) // 예시 거리: 20
            {
                Destroy(gameObject);
            }
        }

        private Transform FindClosestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float closestDistanceSqr = Mathf.Infinity;
            Transform closestEnemy = null;

            // 현재 위치에서 가장 가까운 적을 찾습니다.
            foreach (GameObject enemy in enemies)
            {
                Vector3 directionToTarget = enemy.transform.position - transform.position;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestEnemy = enemy.transform;
                }
            }
            return closestEnemy;
        }
    }
}