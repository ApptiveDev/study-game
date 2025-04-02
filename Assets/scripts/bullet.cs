using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // 총알 속도
    [SerializeField] private float damage = 10f;
    private GameObject target; // 총알이 향하는 목표
    private Vector3 direction; // 총알이 향하는 방향
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAI enemy = FindFirstObjectByType<enemyAI>();
        if (enemy != null)
        {
            target = enemy.gameObject; // 적을 목표로 설정
            direction = (target.transform.position - transform.position).normalized; // 방향 계산
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            Destroy(gameObject);
        }
        transform.position += direction * speed * Time.deltaTime; // 총알 이동
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyAI enemy = collision.GetComponent<enemyAI>();

        if (enemy != null) {
            enemy.health -= damage; // 적의 체력 감소
            if (enemy.health <= 0) {
                Destroy(collision.gameObject); // 적이 죽으면 제거
                Destroy(gameObject); // 총알도 제거
            }
            
        }
    }
}
