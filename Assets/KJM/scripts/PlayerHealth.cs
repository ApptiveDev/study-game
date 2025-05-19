using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace KJM
{
    public class PlayerHealth : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite idleSprite;
        [SerializeField] public Sprite deadSprite;
        [SerializeField] public float health = 500f;
        public Button Restart;
        float damage = 10f;

        private void Start()
        {
            Restart = GameObject.Find("restartButton")?.GetComponent<Button>();
            Restart.onClick.AddListener(RestartButton);
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = idleSprite;
            Restart.gameObject.SetActive(false);
        }
        void RestartButton()
        {
            Time.timeScale = 1f;
            health = 500f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Restart.gameObject.SetActive(false);
        }
        public Sprite GetDeadSprite()
        {
            return deadSprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //���� �浹�ߴ��� Ȯ��, ���� �浹�ϸ� player �� health ����
            if (collision.CompareTag("Enemy"))
            {
                health -= damage;
                Debug.Log("player health: " + health);

                //�÷��̾��� ü���� 0�̸� �״´�. ���� ����.
                if (health <= 0)
                {
                    GetComponent<Animator>().enabled = false;
                    spriteRenderer.sprite = deadSprite;
                    Time.timeScale = 0f;
                    Restart.gameObject.SetActive(true);
                }
            }
        }
    }

}
