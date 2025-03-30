using UnityEngine;

public class playerMove : MonoBehaviour
{
    // 변수 선언.
    public float moveSpeed = 1f;

    Rigidbody2D rigid;

    // 게임이 작동하기 시작할 때 함수 실행.
    private void Awake()
    {
        transform.position = Vector3.zero;
    }

    // 게임 시작 함수.
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // 그래픽 & 인풋 업데이트.
    void Update()
    {

    }

    // 물리 엔진 업데이트.
    void FixedUpdate()
    {
        Move();
    }

    // 이동 함수.
    void Move()
    {
        Vector3 dirVector = Vector3.zero;

        // X축 이동.
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            dirVector = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            dirVector = Vector3.right;
        }

        // Y축 이동.
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            dirVector = Vector3.down;
        }

        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            dirVector = Vector3.up;
        }

        // Transform에 이동방향*속도 할당. detaTime을 곱해줘 자연스러운 움직임 구현.
        transform.position += dirVector * moveSpeed * Time.deltaTime;
    }
}
