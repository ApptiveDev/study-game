using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collision collision;
    private Transform player;

    public float speed = 12f;
    public float lifeTime = 30f;

    private void rotateToTarget(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //이동 방향으로 기수 회전
        rotateToTarget(direction);
    }
    private void OnTriggerEnter2D(Collider2D collision) // 충돌했을 때
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // 적 게임 오브젝트를 지운다.
            Destroy(gameObject); // 적 게임 오브젝트를 지운다.
            collision.gameObject.SetActive(false); // 적 게임 오브젝트를 끈다.
            gameObject.SetActive(false); // 본인 오브젝트도 끈다.
        }
    }
}
