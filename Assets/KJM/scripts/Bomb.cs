using System.Collections;
using UnityEngine;

namespace KJM
{
    public class Bomb : MonoBehaviour
    {
        private Vector3 targetPos;
        private float moveSpeed = 5f;
        public GameObject fireZone; // 화염지대


        private void Start()
        {
            //플레이어 기준 반지름 3 안쪽에서 랜덤 방향 설정
            Vector2 randomOff = Random.insideUnitCircle.normalized * 3f;
            targetPos = transform.position + (Vector3)randomOff;
            StartCoroutine(MoveBomb());
        }

        private IEnumerator MoveBomb()
        {
            //목표위치 도착할때까지 반복하기
            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            //firezone 활성화
            Instantiate(fireZone, transform.position, Quaternion.identity);
            Destroy(gameObject); // 화염병 삭제
        }
    }

}
