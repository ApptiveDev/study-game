using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� �浹�ߴ��� Ȯ��, ���� �浹�ϸ� player �� health ����
        if (collision.CompareTag("Enemy"))
        {
            health -= damage;
            Debug.Log("player health: " + health);

            //�÷��̾��� ü���� 0�̸� �����ȴ�.
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
