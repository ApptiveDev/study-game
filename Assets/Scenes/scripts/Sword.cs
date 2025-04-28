using UnityEngine;

public class Sword : MonoBehaviour
{
    Rigidbody2D rb;
    float positionY = 10f;
    float positionX = 3f;
    float damage = 10f;
    float spinSpeed = 600f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 force = new Vector2(Random.Range(-positionX, positionX), positionY);
            rb.AddForce(force, ForceMode2D.Impulse);
            //È¸Àü¼Óµµ ·»´ý ¼³Á¤
            rb.angularVelocity = Random.Range(-spinSpeed, spinSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.health -= damage;
        }
    }
}