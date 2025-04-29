using UnityEngine;

public class message : MonoBehaviour
{
    [Header("데미지")]
    public int damage = 5;


    private Collider2D _myCollider;
    private Collider2D _playerCollider;
    void Awake()
    {
        _myCollider = GetComponent<Collider2D>();

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            _playerCollider = player.GetComponent<Collider2D>();

        if (_playerCollider != null)
            Physics2D.IgnoreCollision(_myCollider, _playerCollider);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // 충돌한 대상이 enemyAI 스크립트를 가지고 있으면
        var enemy = col.collider.GetComponent<enemyAI>();
        if (enemy != null)
        {
            // 체력 차감
            enemy.health -= damage;
            if (enemy.health <= 0f)
                Destroy(enemy.gameObject);
        }
    }
}