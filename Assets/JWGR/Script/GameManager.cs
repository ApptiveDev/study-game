using UnityEngine;
using System.Collections;

namespace JWGR
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public static int money = 0;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {

        }
    }
}