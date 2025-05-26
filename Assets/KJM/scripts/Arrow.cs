using System.Collections;
using UnityEngine;

namespace KJM
{
    public class Arrow : MonoBehaviour
    {
        GameObject target;
        Vector3 moveDir; // 이동방향 벡터
        float moveSpeed = 5f; //무기 이동 속도
        public float damage = 10f; //무기 데미지
        public int cnt = 1;

        private void Start()
        {
            Enemy enemy = FindAnyObjectByType<Enemy>();

            if (enemy != null)
            {
                target = enemy.gameObject;
                moveDir = target.transform.position - transform.position; // 이동 방향 벡터를 계산
                moveDir.Normalize();
            }
            StartCoroutine(MovePosition());
        }

        private IEnumerator MovePosition()
        {
            while (target != null)
            {
                transform.position += moveDir * moveSpeed * Time.deltaTime;

                yield return null;
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision) // 충돌했을 때
        {
            IEnemyDamage enemy = collision.GetComponent<IEnemyDamage>(); // 적의 Enemy 인터페이스.
            if (collision.gameObject == target) // 충돌한 상대가 내가 목표하는 적일 때,
            {
                enemy.TakeDamage(damage); // 충돌한 적의 체력을 데미지만큼 감소시키는 코드
                Destroy(gameObject);
            }

        }
    }


}
