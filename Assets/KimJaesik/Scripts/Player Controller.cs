using UnityEngine;

namespace KJS
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController _instance;

        public static PlayerController Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("PlayerController 인스턴스 미아");
                }
                return _instance;
            }
        }

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

        //레벨
        private int exp = 0;
        private int level = 1;
        private int expToNextLevel = 5;
        [SerializeField] private int baseExpToNextLevel = 5;
        [SerializeField] private float expGrowthFactor = 1.5f;

        [SerializeField] private GameObject levelUpPanel;
        [SerializeField] private WeaponUIManager weaponUIManager;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
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

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("ExpObj"))
            {
                Destroy(collision.gameObject);
                GainExp(1);
            }
        }

        void GainExp(int expAmount)
        {
            exp += expAmount;
            while (exp >= expToNextLevel)
            {
                exp -= expToNextLevel;
                LevelUp();
            }
        }

        void LevelUp()
        {
            level++;
            expToNextLevel = Mathf.RoundToInt(baseExpToNextLevel * Mathf.Pow(expGrowthFactor, level - 1));
            Debug.Log($"레벨 업! 현재 레벨: {level}, 다음 레벨까지 필요 경험치: {expToNextLevel}");

            Time.timeScale = 0f;

            weaponUIManager.OpenWeaponSelection();
        }

        public void Hit()
        {
            GetComponent<SpriteRenderer>().enabled = false; // 외형 숨김
            GetComponent<Collider2D>().enabled = false;     // 충돌 제거
            GetComponent<Rigidbody2D>().simulated = false;  // 물리 제거
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
