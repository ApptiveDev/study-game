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

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            weight = 45;
        }

        public void GetExp() {
            exp++;
            if (exp >= nextExp[level]) {
                level++;
                exp = 0;
            }
        }

    }

}