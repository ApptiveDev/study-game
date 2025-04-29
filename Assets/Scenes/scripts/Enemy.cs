using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    public float health = 50f;
    float moveDistance = 0.003f;
    float enemySpeed = 1f;

    public void SetTarget(GameObject target)
    {
        player = target;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        //player 가 죽지 않은 상태일때 실행.
        if (playerRenderer.sprite != playerHealth.GetDeadSprite())
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 curPosition = transform.position;

            transform.position = Vector3.MoveTowards(curPosition, playerPosition, enemySpeed * Time.deltaTime);
            if (health <= 0) // 적 체력이 0 이하인 경우
            {
                Destroy(gameObject); // 적 게임 오브젝트를 지운다.
            }
        }
    }
}