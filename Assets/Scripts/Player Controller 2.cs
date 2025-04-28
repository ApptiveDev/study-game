using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody2D rb;

    //이동
    public float maxSpeed = 100f;
    public float acceleration = 50f;
    public float deceleration = 30f;
    private float currentSpeed = 0f;

    private float moveInput;
    private float turnInput;

    //회전
    public float turnSpeed = 300f;
    public float turnLerpSpeed = 5f;
    private float currentTurnSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        if (moveInput > 0)
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
        }
        else if (moveInput < 0)
        {
            currentSpeed -= acceleration * Time.fixedDeltaTime;
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        rb.linearVelocity = transform.up * currentSpeed;
    }

    void HandleRotation()
    {
        float targetTurnSpeed = -turnInput * turnSpeed;
        currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetTurnSpeed, turnLerpSpeed * Time.fixedDeltaTime);

        rb.MoveRotation(rb.rotation + currentTurnSpeed * Time.fixedDeltaTime);
    }
}