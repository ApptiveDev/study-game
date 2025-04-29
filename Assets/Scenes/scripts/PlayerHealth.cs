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
        //���� �浹�ߴ��� Ȯ��, ���� �浹�ϸ� player �� health ����
        if (collision.CompareTag("Enemy"))
        {
            health -= damage;
            Debug.Log("player health: " + health);

            //�÷��̾��� ü���� 0�̸� �״´�. ���� ����.
            if (health <= 0)
            {
                GetComponent<Animator>().enabled = false;
                spriteRenderer.sprite = deadSprite;
                Time.timeScale = 0f;
            }
        }
    }
}
