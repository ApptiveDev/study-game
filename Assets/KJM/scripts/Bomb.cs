using System.Collections;
using UnityEngine;

namespace KJM
{
    public class Bomb : MonoBehaviour
    {
        private Vector3 targetPos;
        private float moveSpeed = 5f;
        public GameObject fireZone; // ȭ������


        private void Start()
        {
            //�÷��̾� ���� ������ 3 ���ʿ��� ���� ���� ����
            Vector2 randomOff = Random.insideUnitCircle.normalized * 3f;
            targetPos = transform.position + (Vector3)randomOff;
            StartCoroutine(MoveBomb());
        }

        private IEnumerator MoveBomb()
        {
            //��ǥ��ġ �����Ҷ����� �ݺ��ϱ�
            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            //firezone Ȱ��ȭ
            Instantiate(fireZone, transform.position, Quaternion.identity);
            Destroy(gameObject); // ȭ���� ����
        }
    }

}
