using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace KJM
{
    public class Wand : MonoBehaviour
    {
        private Vector3 targetPos;
        private float moveSpeed = 4f;
        public GameObject Holes; //홀 발생
        public int cnt = 1;

        private void Start()
        {
            //플레이어 기준 반지름 5 안쪽에서 랜덤 방향 뽑고 저장한다.
            Vector2 randomOff = Random.insideUnitCircle.normalized * 5f;
            targetPos = transform.position + (Vector3)randomOff;
            //가장 마지막에 설정된 targetPos 로 지팡이 던지기
            StartCoroutine(MoveWand());
        }

        private IEnumerator MoveWand()
        {
            //목표위치 도착할때까지 반복하기
            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            //Holl 2개를 랜덤 위치에 생성한다.
            Instantiate(Holes, targetPos, Quaternion.identity);
           
            Destroy(gameObject);
        }
    }

}
