using UnityEngine;
namespace AJH {
    public class cheeseAI : MonoBehaviour
    {

        [Header("추격 속도")] public float moveSpeed = 5f;

        [Header("몹 데미지")] [SerializeField] private float damage = 10f;


        private Transform playerTransform;
        private SpriteRenderer spriteRenderer;
        private Vector2 chaseDir;
        void Start()
        {
            if (player.Instance != null)
                playerTransform = player.Instance.transform; // 플레이어의 Transform을 가져옴

            spriteRenderer = GetComponent<SpriteRenderer>();
            chaseDir = (playerTransform.position - transform.position).normalized;
            if (chaseDir.x < 0) spriteRenderer.flipX = true;
            else if (chaseDir.x > 0) spriteRenderer.flipX = false;

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += (Vector3)(chaseDir * Time.deltaTime);
            // 일정 시간 후 소멸
            Destroy(gameObject, 20f);

        }

        private void OnTriggerEnter2D(Collider2D other) {
            
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.GetWeight(damage); // 플레이어에게 데미지
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Weapon"))
            {
                Destroy(gameObject); // 벽에 닿으면 오브젝트 삭제
            }
            

        }


        
    }

}
