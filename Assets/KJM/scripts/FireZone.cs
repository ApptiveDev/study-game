using UnityEngine;

public class FireZone : MonoBehaviour
{
    public float damage = 10f; // firezone ������ �ִ� ���� �ʴ� ������
    public float duration = 5f;
    void Start()
    {
        Destroy(gameObject, duration);
    }

    //����Ƽ �ڵ�ȣ���Լ� ���
    //fire zone �� ���� enemy �� health �� �ʴ� ���ҽ�Ų��.
    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null){
            enemy.health -= damage * Time.deltaTime;
        }
    }
}
