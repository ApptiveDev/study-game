using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] public Sprite deadSprite;
    [SerializeField] float health = 500f;
    float damage = 10f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;
    }

    public Sprite GetDeadSprite()
    {
        return deadSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적과 충돌했는지 확인, 적과 충돌하면 player 의 health 감소
        if (collision.CompareTag("Enemy"))
        {
            health -= damage;
            Debug.Log("player health: " + health);

            //플레이어의 체력이 0이면 죽는다. 게임 종료.
            if (health <= 0)
            {
                GetComponent<Animator>().enabled = false;
                spriteRenderer.sprite = deadSprite;
                Time.timeScale = 0f;
            }
        }
    }
}
