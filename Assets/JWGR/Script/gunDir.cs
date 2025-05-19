using UnityEditor.Rendering;
using UnityEngine;

namespace JWGR
{
    public class gunDir : MonoBehaviour
    {
        private Transform target; // 타겟의 트랜스폼
        public GameObject player;
        private Vector3 dir; // 이동 방향 벡터
        private float rotationSpeed = 20f;
        public float angle = 0f;

        SpriteRenderer playerRenderer;
        SpriteRenderer gunRenderer;

        private void Awake()
        {
            playerRenderer = player.GetComponent<SpriteRenderer>();
            gunRenderer = GetComponent<SpriteRenderer>();
            GetComponent<SpriteRenderer>().sortingOrder = 9;
        }

        private void Update()
        {
            target = FindClosestEnemy();

            if (playerRenderer.flipX) // 플레이어가 왼쪽을 보고 있을때
            {
                gunRenderer.flipX = false;
            }
            else // 플레이어가 오른쪽을 보고 있을때
            {
                gunRenderer.flipX = true;
            }

            if (target != null)
            {
                dir = (target.position - transform.position).normalized; // 초기 이동 방향 벡터를 계산하고 정규화합니다.
            }

            // 오브젝트가 목표 적을 바라보도록 회전
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (gunRenderer.flipX)
            {
                if (angle <= 90 && angle >= -90)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, angle); // 이미지가 위를 향하고 있으므로 -90도 보정
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * rotationSpeed * 0.5f);
                }
            }
            else
            {
                if (angle <= -90 || angle >= 90)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, angle - 180f); // 이미지가 위를 향하고 있으므로 -90도 보정
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * rotationSpeed * 0.5f);
                }
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