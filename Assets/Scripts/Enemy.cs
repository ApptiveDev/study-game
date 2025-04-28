using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collision collision;
    private Transform player;

    public float speed = 12f;
    public float lifeTime = 30f;

    private void rotateToTarget(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //�̵� �������� ��� ȸ��
        rotateToTarget(direction);
    }
    private void OnTriggerEnter2D(Collider2D collision) // �浹���� ��
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // �� ���� ������Ʈ�� �����.
            Destroy(gameObject); // �� ���� ������Ʈ�� �����.
            collision.gameObject.SetActive(false); // �� ���� ������Ʈ�� ����.
            gameObject.SetActive(false); // ���� ������Ʈ�� ����.
        }
    }
}
