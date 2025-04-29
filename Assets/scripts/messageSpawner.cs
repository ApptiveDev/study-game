using UnityEngine;
using System.Collections;
namespace AJH {

    public class messageSpawner : MonoBehaviour
    {
        [Header("메세지지 프리팹 (필수)")]
        [SerializeField] private GameObject messagePrefab;

        [Header("던지는 간격 (초)")]
        [SerializeField] private float throwInterval = 1f;

        [Header("초기 속도 X (수평)")]
        [SerializeField] private float initialSpeedX = 5f;

        [Header("초기 속도 Y (수직)")]
        [SerializeField] private float initialSpeedY = 5f;

        [Header("투사체 수명 (초)")]
        [SerializeField] private float projectileLifetime = 3f;

        private bool _throwLeft = true;

        void Start()
        {
            StartCoroutine(ThrowMessages());
        }

        private IEnumerator ThrowMessages()
        {
            while (true)
            {
                ThrowOneMessage();
                yield return new WaitForSeconds(throwInterval);
            }
        }

        private void ThrowOneMessage()
        {
            if (messagePrefab == null) return;

            // 플레이어 위치에서 인스턴스 생성
            var mes = Instantiate(messagePrefab, transform.position, Quaternion.identity);

            // Rigidbody2D가 있으면 초기 속도 부여
            var rb = mes.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float dir = _throwLeft ? -1f : 1f;
                rb.linearVelocity = new Vector2(initialSpeedX * dir, initialSpeedY);
                // (옵션) 중력 세기 조절
                // rb.gravityScale = 1f;
            }

            // 일정 시간 후 자동 파괴
            Destroy(mes, projectileLifetime);

            // 다음에는 반대 방향으로 던지기
            _throwLeft = !_throwLeft;
        }
    }

}