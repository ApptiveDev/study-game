using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;
namespace AJH{

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public PoolManager pool;
        public player player;
        public bool IsLive = true;

        [Header("Player Info")]
        public float weight = 45f;
        public float maxWeight = 100f;
        public int level;
        public int exp;
        public int kill = 0;
        public int[] nextExp = { 3, 5, 10, 30, 60, 100, 150 };
        public GameObject[] expPrefab;
        [SerializeField] private GameObject bossPrefab;
        [SerializeField] private CanvasGroup gameOverPanel;
        [SerializeField] private CanvasGroup UIcanvas;
        public levelUp levelUpUI;


        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            levelUpUI.Select(0);
        }


        public void GetExp(int expAmount)
        {
            //시간 멈추기

            exp += expAmount;
            if (exp >= nextExp[level])
            {
                exp = 0;
                // exp가 0이아니라 넘친 만큼 되어야할거같은데 
                // 그렇게 하니까 뭔가 이상하게 동작함...
                level++;
                levelUpUI.Show();
                if (level == 3)
                {
                    Instantiate(bossPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    BGMManager.instance.PlayBossBGM();
                }
                
            }

        }

        private void GameOver()
        {
            // 게임 오버 처리
            UIcanvas.alpha = 0;
            gameOverPanel.alpha = 1;
            BGMManager.instance.playGameOverBGM();
            IsLive = false;
            player.transform.localScale = new Vector3(3f, 3f, 1f);
            Time.timeScale = 0;


        }


        public void GetWeight(float damage)
        {
            weight += damage;
            // player.GetComponent
            // 이거 무게 늘면 커지는거 추후 구현 예정
            if (weight >= maxWeight)
            {
                GameOver();
            }
        }

        public void Stop()
        {
            IsLive = false;
            Time.timeScale = 0;
        }
        
        public void Resume()
        {
            IsLive = true;
            Time.timeScale = 1;
        }

    }

}