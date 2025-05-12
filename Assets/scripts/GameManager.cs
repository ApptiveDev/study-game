using UnityEngine;
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

        void Awake()
        {
            instance = this;
        }


        public void GetExp(int expAmount) {
            exp+= expAmount;
            if (exp >= nextExp[level]) {
                exp = 0;
                // exp가 0이아니라 넘친 만큼 되어야할거같은데 
                // 그렇게 하니까 뭔가 이상하게 동작함...
                level++;
            }
        }

        public void GetWeight(float damage) {
            weight += damage;
        }

    }

}