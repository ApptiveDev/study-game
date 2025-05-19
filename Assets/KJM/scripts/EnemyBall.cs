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
            // �÷��̾� ��ġ ������ �����. ������ �������� ���� �߻�.
            Vector3 playerPos = Player.Instance.transform.position;
            targetDirection = (playerPos - transform.position).normalized;
            StartCoroutine(MoveTo());
            Destroy(gameObject, lifetime); // lifetime �ð� ����� ���� �ı�
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
