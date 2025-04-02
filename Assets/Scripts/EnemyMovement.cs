using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float MaxHealth = 10f;
    [SerializeField] private float health = 10f;
    private GameObject target;
    private Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void Damaged(float damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return this.health;
    }

    public float GetMaxHealth()
    {
        return this.MaxHealth;
    }
}
