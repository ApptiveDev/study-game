using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;

    public float health = 50f;
    float moveDistance = 0.003f;
    float enemySpeed = 1f;

    public void SetTarget(GameObject target)
    {
        player = target;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 curPosition = transform.position;

            transform.position = Vector3.MoveTowards(curPosition, playerPosition, enemySpeed * Time.deltaTime);
            if (health <= 0) // �� ü���� 0 ������ ���
            {
                Destroy(gameObject); // �� ���� ������Ʈ�� �����.
            }
        }
    }
}