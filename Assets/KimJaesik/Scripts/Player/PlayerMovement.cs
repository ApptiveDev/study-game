using UnityEngine;

namespace KJS
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("이동 설정")]
        public float maxSpeed = 100f;
        public float acceleration = 50f;
        public float deceleration = 30f;

        [Header("회전 설정")]
        public float turnSpeed = 300f;
        public float turnLerpSpeed = 5f;

        private Rigidbody2D rb;
        private float currentSpeed = 0f;
        private float currentTurnSpeed = 0f;

        private float moveInput;
        private float turnInput;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            moveInput = Input.GetAxisRaw("Vertical");
            turnInput = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
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

        private void HandleRotation()
        {
            float targetTurnSpeed = -turnInput * turnSpeed;
            currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetTurnSpeed, turnLerpSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation + currentTurnSpeed * Time.fixedDeltaTime);
        }
    }
}
