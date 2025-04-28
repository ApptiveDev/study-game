using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject target;
    Vector3 moveDir; // �̵����� ����
    float moveSpeed = 5f; //���� �̵� �ӵ�
    float damage = 10f; //���� ������

    private void Start()
    {
        Enemy enemy = FindAnyObjectByType<Enemy>();
        
        if(enemy != null)
        {
            target = enemy.gameObject;
            moveDir = target.transform.position - transform.position; // �̵� ���� ���͸� ���
            moveDir.Normalize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        transform.position += moveDir * moveSpeed * Time.deltaTime;
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

