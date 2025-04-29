using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KJM
{
    public class Arrow : MonoBehaviour
    {
        GameObject target;
        Vector3 moveDir; // �̵����� ����
        float moveSpeed = 5f; //���� �̵� �ӵ�
        float damage = 10f; //���� ������

        private void Start()
        {
            Enemy enemy = FindAnyObjectByType<Enemy>();

            if (enemy != null)
            {
                target = enemy.gameObject;
                moveDir = target.transform.position - transform.position; // �̵� ���� ���͸� ���
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

        private void OnTriggerEnter2D(Collider2D collision) // �浹���� ��
        {
            Enemy enemy = collision.GetComponent<Enemy>(); // ���� Enemy ��ũ��Ʈ ����.
            if (enemy.gameObject == target) // �浹�� ��밡 ���� ��ǥ�ϴ� ���� ��,
            {
                enemy.health -= damage; // �浹�� ���� ü���� ��������ŭ ���ҽ�Ű�� �ڵ�
                Destroy(gameObject);
            }

        }
    }


}
