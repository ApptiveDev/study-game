using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private SpriteRenderer spriteRenderer;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right *Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        transform.position += Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    }

    void LateUpdate()
    {
        //움직임 애니메이션 설정
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));
        
        
        float horizontalInput = Input.GetAxis("Horizontal");

        // 좌우 이동 입력에 따라 flipX 설정
        if (horizontalInput < 0) spriteRenderer.flipX = true;
        else if (horizontalInput > 0) spriteRenderer.flipX = false;

    }
        
}
