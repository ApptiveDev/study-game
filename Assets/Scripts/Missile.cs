using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;

    void Start()
    {
        target = GameObject.FindWithTag("Target").transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //이동 방향으로 기수 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
