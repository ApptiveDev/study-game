using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject target;
    Vector3 moveDir; // �̵����� ����
    float moveSpeed = 3f; //ȭ�� �̵� �ӵ�
    float damage = 10f; //ȭ�� ������
    private void Start()
    {
        Enemy enemy = FindObjectOfType<Enemy>();
        if(enemy != null)
        {
            target = enemy.gameObject; // Ÿ���� ���� ������Ʈ�� ����
            moveDir = target.transform.position - transform.position; // �̵� ���� ���͸� ���
            moveDir.Normalize(); // �̵� ���� ���� ����ȭ
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
        Enemy enemy = collision.GetComponent<Enemy>(); // ���� Enemy ��ũ��Ʈ�� �����Ѵ�.
        if (enemy.gameObject == target) // �浹�� ��밡 ���� ��ǥ�ϴ� ���� ��,
        {
            enemy.health -= damage; // �浹�� ���� ü���� ��������ŭ ���ҽ�Ű�� �ڵ�
            if (enemy.health <= 0) // �� ü���� 0 ������ ���
            {
                Destroy(collision.gameObject); // �� ���� ������Ʈ�� �����.
                                               // �� ���� ������Ʈ�� �����.
                                               //collision.gameObject.SetActive(false); // �� ���� ������Ʈ�� ����.
                                               //gameObject.SetActive(false); // ���� ������Ʈ�� ����.

            }
            Destroy(gameObject);
        }

    }
}

