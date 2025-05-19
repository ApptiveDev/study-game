using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JWGR
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        // 변수 선언.
        [SerializeField] Slider expBar;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject levelManager;
        public float moveSpeed = 3f;
        public float HP = 100f;
        public int Level = 0;
        public int minExp = 0;
        public int maxExp = 0;
        public int tempExp = 0;
        private GameObject collisionObject;
        private SpriteRenderer render;

        // 게임이 작동하기 시작할 때 함수 실행.
        private void Awake()
        {
            levelManager.GetComponent<levelManage>().CloseLevelUpPanel();
            transform.position = Vector3.zero;
            render = gameObject.GetComponent<SpriteRenderer>();
            gameOverPanel.SetActive(false);
        }

        // 물리 엔진 업데이트.
        private void FixedUpdate()
        {
            Move();
            ManageExp();
        }

        // 이동 함수.
        private void Move()
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

        private void ManageExp()
        {
            if (tempExp >= maxExp) 
            {
                Level += 1;
                tempExp -= maxExp;
                maxExp = 5 * (int)Math.Pow(2, Level);
                expBar.maxValue = maxExp;
                levelManager.GetComponent<levelManage>().OpenLevelUpPanel();
            }
            expBar.value = tempExp;
        }

        private void OnTriggerEnter2D(Collider2D collision) // 충돌했을 때
        {
            if (collision.gameObject != null)
            {
                collisionObject = collision.gameObject;
                if (collisionObject.gameObject.CompareTag("Enemy")) // 충돌한 상대가 적일 때
                {
                    if (!collisionObject.GetComponent<enemyInfo>().isRange)
                    {
                        HP -= collisionObject.GetComponent<enemyInfo>().damage;
                    }
                }
                if (collisionObject.gameObject.CompareTag("EnemyWeapon"))
                {
                    HP -= collisionObject.GetComponent<ItemData>().damage;
                    Destroy(collision.gameObject); //오브젝트를 지운다.
                }
                else if (collisionObject.gameObject.CompareTag("Exp"))
                {
                    tempExp += 1;
                    Destroy(collision.gameObject);
                }

                if (HP <= 0)
                {
                    gameOverPanel.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }
    }
}