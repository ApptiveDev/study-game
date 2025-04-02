using UnityEngine;

public class BombEffect : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyMovement>().Damaged(damage);
        }
    }
}
