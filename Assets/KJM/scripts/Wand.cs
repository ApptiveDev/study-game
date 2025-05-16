using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace KJM
{
    public class Wand : MonoBehaviour
    {
        private Vector3 targetPos;
        private float moveSpeed = 4f;
        public GameObject Holes; // 3���� Ȧ �߻�
        private List<Vector3> targetPoses = new List<Vector3>();

        private void Start()
        {
            //�÷��̾� ���� ������ 3 ���ʿ��� ���� ���� 3���� �̰� �����Ѵ�.
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
            //���� �������� ������ targetPos �� ������ ������
            StartCoroutine(MoveWand());
        }

        private IEnumerator MoveWand()
        {
            //��ǥ��ġ �����Ҷ����� �ݺ��ϱ�
            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            //Holl 3���� ���� ��ġ�� �����Ѵ�.
            for (int i = 0; i < 3; i++)
            {
                Instantiate(Holes, targetPoses[i], Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
