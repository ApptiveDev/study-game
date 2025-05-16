using UnityEngine;

namespace KJM
{
    public class Holes : MonoBehaviour
    {
        public float duration = 2f; //홀은 2초간 유지된다.
        void Start()
        {
            Destroy(gameObject, duration);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                Destroy(enemy); // 생성된 holde 안에 들어온 적은 소멸한다.
            }
        }
    }

}
