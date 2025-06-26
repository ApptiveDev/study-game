using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
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
        public float totalMoney = 0f; // 총 벌어들인 돈
        public float currentMoney = 0f;
        public float moneyIncrease = 0f; // 돈 증가량
        public int[] nextExp = { 3, 5, 10, 30, 60, 100, 150 };
        public GameObject[] expPrefab;
        [SerializeField] private GameObject bossPrefab;
        [SerializeField] private CanvasGroup gameOverPanel;
        [SerializeField] private CanvasGroup UIcanvas;
        [SerializeField] private Text gameOverText;
        public levelUp levelUpUI;


        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("TotalMoney")) totalMoney = PlayerPrefs.GetFloat("TotalMoney");
            else totalMoney = 0f;
            
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
            currentMoney += math.round(currentMoney * moneyIncrease); // 이번 라운드에 번 돈
            totalMoney += currentMoney;

            PlayerPrefs.SetFloat("TotalMoney", totalMoney);
            PlayerPrefs.Save();

            gameOverText.text = $"열심히 참아서 {currentMoney}원을 벌었습니다.";
            BGMManager.instance.playGameOverBGM();
            IsLive = false;
            player.transform.localScale = new Vector3(3f, 3f, 1f);

            Time.timeScale = 0;
            currentMoney = 0f; // 다음 라운드에 번 돈 초기화
            exp = 0; // 경험치 초기화
            level = 0; // 레벨 초기화

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