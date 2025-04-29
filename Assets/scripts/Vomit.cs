using UnityEngine;
namespace AJH {

    public class NewMonoBehaviourScript1 : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private GameObject target;
        private Vector3 moveDirection;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float damage = 5f;


        void Start()
        {
            enemyAI enemy = FindObjectOfType<enemyAI>();
            if (enemy != null)
            {
                target = enemy.gameObject; // enemyAI 스크립트가 붙은 오브젝트를 찾음
                moveDirection = (target.transform.position - transform.position).normalized; // 이동 방향 계산
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
            enemyAI enemy = collision.GetComponent<enemyAI>();
            if (enemy != null)
            {
                enemy.health -= damage; // 적의 체력 감소
                if (enemy.health <= 0)
                {
                    Destroy(collision.gameObject); // 적이 죽으면 오브젝트 삭제
                }
                Destroy(gameObject); // 이 오브젝트 삭제
            }
        }
    }

}