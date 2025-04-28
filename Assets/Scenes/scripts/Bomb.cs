using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Vector3 targetPos;
    private float moveSpeed = 5f;
    public GameObject fireZone; // 화염지대
  

    private void Start()
    {
        //플레이어 기준 반지름 3 안쪽에서 랜덤 방향 설정
        Vector2 randomOff = Random.insideUnitCircle.normalized * 3f;
        targetPos = transform.position + (Vector3)randomOff;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        //목표위치에 도착시
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            Instantiate(fireZone, transform.position, Quaternion.identity);
            Destroy(gameObject); // 화염병 삭제
        }
    }
}
