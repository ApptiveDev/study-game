using UnityEngine;

namespace KJM
{
    public class Coin : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Player.Instance.exp += 1;
                Debug.Log(Player.Instance.exp);
                Destroy(gameObject);
            }
        }
    }
}

