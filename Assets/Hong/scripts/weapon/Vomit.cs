using UnityEngine;
namespace AJH {

    public class Vomit : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private GameObject target;
        private Vector3 moveDirection;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float damage = 5f;


        void Start()
        {
            chooseTarget(); // 타겟 선택
            
        }

        void chooseTarget() {
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy"); // enemy 태그를 가진 오브젝트 찾기
            if (enemy.Length != 0)
            {
                while (true)
                {
                    int index = Random.Range(0, enemy.Length);
                    if (enemy[index] != null)
                    {
                        target = enemy[index].gameObject; // enemyAI 스크립트가 붙은 오브젝트를 찾음
                        break;
                    } 
                    
                }
                moveDirection = (target.transform.position - transform.position).normalized; // 이동 방향 계산

            }
            else
            {
                moveDirection = Vector2.right;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                Destroy(gameObject); // 타겟이 없으면 오브젝트 삭제
                return;
            }
            transform.position += moveDirection * moveSpeed * Time.deltaTime; // 이동
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage); // 데미지 적용
                Destroy(gameObject); // 오브젝트 삭제
            }
        }
    }

}