using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적과 충돌했는지 확인, 적과 충돌하면 player 의 health 감소
        if (collision.CompareTag("Enemy"))
        {
            health -= damage;
            Debug.Log("player health: " + health);

            //플레이어의 체력이 0이면 삭제된다.
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
