using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace KJM
{
    public class Wand : MonoBehaviour
    {
        private Vector3 targetPos;
        private float moveSpeed = 4f;
        public GameObject Holes; // 3개의 홀 발생
        private List<Vector3> targetPoses = new List<Vector3>();

        private void Start()
        {
            //플레이어 기준 반지름 3 안쪽에서 랜덤 방향 3개를 뽑고 저장한다.
            while (targetPoses.Count < 3)
            {
                Vector2 randomOff = Random.insideUnitCircle.normalized * 3f;
                targetPos = transform.position + (Vector3)randomOff;
                if (targetPoses.Contains(targetPos))
                {
                    continue;
                }
                else
                {
                    targetPoses.Add(targetPos);
                }
            }
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
            //Holl 3개를 랜덤 위치에 생성한다.
            for (int i = 0; i < 3; i++)
            {
                Instantiate(Holes, targetPoses[i], Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
