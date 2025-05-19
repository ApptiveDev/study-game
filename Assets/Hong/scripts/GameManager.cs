using UnityEngine;
using UnityEngine.UIElements;
namespace AJH{

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public PoolManager pool;
        public player player;

        [Header("Player Info")]  
        public float weight = 45f;
        public float maxWeight = 100f;
        public int level;
        public int exp;
        public int kill;
        public int[] nextExp = {3, 5, 10, 30, 60, 100, 150};
        public GameObject[] expPrefab;
        public levelUp levelUpUI;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            levelUpUI.Select(0);   
        }


        public void GetExp(int expAmount) {
            exp+= expAmount;
            if (exp >= nextExp[level]) {
                exp = 0;
                // exp가 0이아니라 넘친 만큼 되어야할거같은데 
                // 그렇게 하니까 뭔가 이상하게 동작함...
                level++;
                levelUpUI.Show();
            }
        }

        public void GetWeight(float damage) {
            weight += damage;
            // player.GetComponent
            // 이거 무게 늘면 커지는거 추후 구현 예정
        }
    }

}