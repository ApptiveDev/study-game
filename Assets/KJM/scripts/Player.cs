using UnityEngine;

namespace KJM
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); //신이 바껴도 오브젝트 유지
            }
            else
            {
                Destroy(gameObject);
            }
        }
        //외부에서 읽을수만 있고 수정은 하지 못한다.
        public PlayerMovement Movement { get; private set; }
        public PlayerHealth Health { get; private set; }
        public SpriteRenderer Renderer { get; private set; }

        private void Start()
        {
            Renderer = GetComponent<SpriteRenderer>();
            Movement = GetComponent<PlayerMovement>();
            Health = GetComponent<PlayerHealth>();
        }
    }

}
