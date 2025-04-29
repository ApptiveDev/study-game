using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float horizontalInput;
    private float verticalInput;
    public Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized; // 이동 방향 계산
        transform.position += Vector3.right * horizontalInput * Time.deltaTime * moveSpeed;
        transform.position += Vector3.up * verticalInput * Time.deltaTime * moveSpeed;
    }

    void LateUpdate()
    {
        //움직임 애니메이션 설정
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)); // 애니메이션 속도 설정
        // 좌우 이동 입력에 따라 flipX 설정
        if (horizontalInput < 0) spriteRenderer.flipX = true;
        else if (horizontalInput > 0) spriteRenderer.flipX = false;

    }
        
}
