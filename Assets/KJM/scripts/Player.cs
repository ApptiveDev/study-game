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
                DontDestroyOnLoad(gameObject); //���� �ٲ��� ������Ʈ ����
            }
            else
            {
                Destroy(gameObject);
            }
        }
        //�ܺο��� �������� �ְ� ������ ���� ���Ѵ�.
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
