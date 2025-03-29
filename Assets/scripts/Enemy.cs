using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    float enemySpeed;

    // 플레이어 오브젝트 전달
    public void SetTarget(GameObject target)
    {
        player = target;
    }

    /*1- 10 : 스피드 1
         * 10-20 : 스피드 2
         * 20-30 : 스피트 3
         * 30이후 : 스피트 4
        */
    public void SetSpeed()
    {
        float time = Time.time;
        if (time <= 30)
        {
            enemySpeed = 1f + Time.time / 10;
        }
        else enemySpeed = 4f;
    }

    // 적이 생성될때마다 속도 계산.
    private void Start()
    {
        SetSpeed();
    }

    //플레이어를 따라가는 적 구현
    private void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 curPosition = transform.position;
        transform.position = Vector3.MoveTowards(curPosition, playerPosition, enemySpeed * Time.deltaTime);
    }
}
