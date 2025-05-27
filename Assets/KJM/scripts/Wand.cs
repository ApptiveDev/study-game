using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace KJM
{
    public class Wand : MonoBehaviour
    {
        private Vector3 targetPos;
        private float moveSpeed = 4f;
        public GameObject Holes; //Ȧ �߻�
        public int cnt = 1;

        private void Start()
        {
            //�÷��̾� ���� ������ 5 ���ʿ��� ���� ���� �̰� �����Ѵ�.
            Vector2 randomOff = Random.insideUnitCircle.normalized * 5f;
            targetPos = transform.position + (Vector3)randomOff;
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
            //Holl 2���� ���� ��ġ�� �����Ѵ�.
            Instantiate(Holes, targetPos, Quaternion.identity);
           
            Destroy(gameObject);
        }
    }

}
