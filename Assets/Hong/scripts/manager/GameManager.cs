using System.ComponentModel;
using System.Collections;
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

        public float defense = 0; // 방어력
        [SerializeField] private StatData[] stats;
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
            InitializeStatPrefs();
            levelUpUI.Select(0);
            ApplyUpgradedStats();
            
        }

        private void InitializeStatPrefs()
        {
            string[] stats = { "Speed", "Defense", "Gold" };
            foreach (string stat in stats)
            {
                if (!PlayerPrefs.HasKey(stat + "_Level"))
                {
                    PlayerPrefs.SetInt(stat + "_Level", 0);
                }
            }
            if (!PlayerPrefs.HasKey("TotalMoney"))
            {
                PlayerPrefs.SetFloat("TotalMoney", 0f);
            }
        }
        public void ApplyUpgradedStats()
        {
            int speedLevel = PlayerPrefs.GetInt("Speed_Level", 0);
            int defenseLevel = PlayerPrefs.GetInt("Defense_Level", 0);
            int goldLevel = PlayerPrefs.GetInt("Gold_Level", 0);

            // stats 배열에서 인덱스 돌며 speed, defense, gold에 해당하는 StatData를 찾아서 적용
            foreach (StatData stat in stats)
            {
                if (stat.statName == "Speed")
                {
                    player.moveSpeed = stat.upgradeValues[speedLevel];
                }
                else if (stat.statName == "Defense")
                {
                    defense = stat.upgradeValues[defenseLevel];
                }
                else if (stat.statName == "Gold")
                {
                    moneyIncrease = stat.upgradeValues[goldLevel];
                }
            }
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
        private IEnumerator WaitForEnterKey()
        {
            // 엔터 누를 때까지 대기
            while (!Input.GetKeyDown(KeyCode.Return))
            {
                yield return null;
            }

            Time.timeScale = 1f; // 시간 재개
            BGMManager.instance.StopBGM();
            UnityEngine.SceneManagement.SceneManager.LoadScene("title"); // 타이틀로 전환

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
            StartCoroutine(WaitForEnterKey());

        }


        public void GetWeight(float damage)
        {
            weight += damage - defense; // 방어력 적용
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