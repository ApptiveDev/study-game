using UnityEngine;

namespace AJH
{
    public class exp : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        [SerializeField] private int expAmout = 1;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GameManager.instance.GetExp(expAmout);
                Destroy(gameObject); // 충돌 시 오브젝트 삭제
            }
        }
    }

}