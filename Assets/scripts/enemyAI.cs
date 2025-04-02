using UnityEngine;

public class enemyAI : MonoBehaviour
{
    [SerializeField] public float spawnInterval; // 플레이어 오브젝트
    public float moveSpeed; // 적의 이동 속도
    private Transform playerTransform; // 플레이어의 Transform 참조
    private SpriteRenderer spriteRenderer;
    private Vector3 direction; // 적의 이동 방향
    public float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // 플레이어 방향 계산 (정규화하여 일정한 속도로 이동)
            direction = (playerTransform.position - transform.position).normalized;
            // 적 위치 업데이트
            transform.position += direction * moveSpeed * Time.deltaTime;
            if (direction.x < 0) spriteRenderer.flipX = true;
            else if (direction.x > 0) spriteRenderer.flipX = false;
            
        }
        
    }

}
