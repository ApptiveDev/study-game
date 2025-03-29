using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    float enemySpeed;

    // �÷��̾� ������Ʈ ����
    public void SetTarget(GameObject target)
    {
        player = target;
    }

    /*1- 10 : ���ǵ� 1
         * 10-20 : ���ǵ� 2
         * 20-30 : ����Ʈ 3
         * 30���� : ����Ʈ 4
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

    // ���� �����ɶ����� �ӵ� ���.
    private void Start()
    {
        SetSpeed();
    }

    //�÷��̾ ���󰡴� �� ����
    private void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 curPosition = transform.position;
        transform.position = Vector3.MoveTowards(curPosition, playerPosition, enemySpeed * Time.deltaTime);
    }
}
