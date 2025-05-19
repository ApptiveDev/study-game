using System.Collections;
using UnityEngine;

namespace KJM
{
    public class EnemyBall : MonoBehaviour
    {
        private Vector3 targetDirection;
        public float speed = 4f;
        public float lifetime = 10f;

        private void Start()
        {
            // 플레이어 위치 방향을 계산함. 일정한 방향으로 무기 발사.
            Vector3 playerPos = Player.Instance.transform.position;
            targetDirection = (playerPos - transform.position).normalized;
            StartCoroutine(MoveTo());
            Destroy(gameObject, lifetime); // lifetime 시간 경과후 무기 파괴
        }

        private IEnumerator MoveTo()
        {
            while (true)
            {
                transform.position += targetDirection * speed * Time.deltaTime;
                yield return null;

            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Player.Instance.Health.health -= 10;
                Destroy(gameObject);
            }
        }
    }
}
