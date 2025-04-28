using UnityEngine;

public class FireZone : MonoBehaviour
{
    public float damage = 10f; // firezone 영역에 있는 동안 초당 데미지
    public float duration = 5f;
    void Start()
    {
        Destroy(gameObject, duration);
    }

    //유니티 자동호출함수 사용
    //fire zone 에 들어온 enemy 의 health 를 초당 감소시킨다.
    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null){
            enemy.health -= damage * Time.deltaTime;
        }
    }
}
