using UnityEngine;
namespace AJH{

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public player player;

        [Header("Player Info")]  
        public int weight;
        public int maxWeight = 100;
        public int level;
        public int exp;
        public int kill;
        public int[] nextExp = {3, 5, 10, 30, 60, 100, 150};
        public GameObject[] expPrefab;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            weight = 45;
        }

        public void GetExp(int expAmount) {
            exp+= expAmount;
            if (exp >= nextExp[level]) {
                exp = nextExp[level] - exp;
                level++;
            }
        }

    }

}