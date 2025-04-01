using UnityEngine;

public class playerMove : MonoBehaviour
{
    // 변수 선언.
    public float moveSpeed = 1f;

    private SpriteRenderer render;

    // 게임이 작동하기 시작할 때 함수 실행.
    private void Awake()
    {
        transform.position = Vector3.zero;
        render = gameObject.GetComponent<SpriteRenderer>();
    }

    // 물리 엔진 업데이트.
    void FixedUpdate()
    {
        Move();
    }

    // 이동 함수.
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dirVector = new Vector3(h, v, 0);

        if (h < 0)
        {
            render.flipX = true;
        }
        else if (h > 0)
        {
            render.flipX = false;
        }

        // Transform에 이동방향*속도 할당. detaTime을 곱해줘 자연스러운 움직임 구현.
        transform.position += dirVector.normalized * moveSpeed * Time.deltaTime;
    }
}
