using UnityEngine;
namespace AJH{

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public player player;

        [Header("Player Info")]  
        public int level;
        public int exp;
        public int kill;
        public int[] nextExp = {3, 5, 10, 30, 60, 100, 150};

        void Awake()
        {
            instance = this;
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