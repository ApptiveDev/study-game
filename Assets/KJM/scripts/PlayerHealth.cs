using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace KJM
{
    public class PlayerHealth : MonoBehaviour
    {
        Animator animator;
        private SpriteRenderer spriteRenderer;
        /*[SerializeField] private Sprite idleSprite;*/
        /*[SerializeField] public Sprite deadSprite;*/
        [SerializeField] public float health = 500f;
        public Button Restart;
        float damage = 10f;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            SceneManager.sceneLoaded += OnSceneLoaded;
/*            Restart = GameObject.Find("restartButton")?.GetComponent<Button>();
            *//*spriteRenderer = GetComponent<SpriteRenderer>();*/
            /* spriteRenderer.sprite = idleSprite;*//*
            Restart.gameObject.SetActive(false);*/
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Restart = GameObject.Find("restartButton")?.GetComponent<Button>();
            if (Restart == null) return;
            Restart.onClick.RemoveAllListeners();
            Restart.onClick.AddListener(RestartButton);
            Restart.gameObject.SetActive(false);
        }

        void RestartButton()
        {
            
            Time.timeScale = 1f;
            Player.Instance.level = 0;
            Player.Instance.exp = 0;
            animator.SetBool("isDeath", false);
            health = 100f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    /*    public Sprite GetDeadSprite()
        {
            return deadSprite;
        }*/

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //적과 충돌했는지 확인, 적과 충돌하면 player 의 health 감소
            if (collision.CompareTag("Enemy"))
            {
                health -= damage;
                Debug.Log("player health: " + health);

                //플레이어의 체력이 0이면 죽는다. 게임 종료.
                if (health <= 0)
                {
                    /*GetComponent<Animator>().enabled = false;
                    spriteRenderer.sprite = deadSprite;*/
                    animator.SetBool("isDeath", true);
                    Time.timeScale = 0f;
                    Restart.gameObject.SetActive(true);
                }
            }
        }
    }

}
