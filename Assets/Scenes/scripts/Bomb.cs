using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Vector3 targetPos;
    private float moveSpeed = 5f;
    public GameObject fireZone; // ȭ������
  

    private void Start()
    {
        //�÷��̾� ���� ������ 3 ���ʿ��� ���� ���� ����
        Vector2 randomOff = Random.insideUnitCircle.normalized * 3f;
        targetPos = transform.position + (Vector3)randomOff;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        //��ǥ��ġ�� ������
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            Instantiate(fireZone, transform.position, Quaternion.identity);
            Destroy(gameObject); // ȭ���� ����
        }
    }
}
