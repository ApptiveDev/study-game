using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 4f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //이동 방향으로 기수 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
