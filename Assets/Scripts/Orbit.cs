using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float damage = 1f;
    private float angle = 0f;

    private void Update()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Layer 3";

        // 각도를 증가시켜 회전 효과
        angle += speed * Time.deltaTime;

        // X, Y 위치를 원운동 수식으로 계산
        float x = player.transform.position.x + Mathf.Cos(angle) * radius;
        float y = player.transform.position.y + Mathf.Sin(angle) * radius;

        // 새로운 위치 적용
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyMovement>().Damaged(damage);
        }
    }
}
