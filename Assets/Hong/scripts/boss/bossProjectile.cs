using UnityEngine;
namespace AJH
{
    // 몬스터의
    public class bossProjectile : MonoBehaviour
    {
        [SerializeField] private float speed = 5f; // 발사체 속도
        [SerializeField] private float damage = 10f; // 발사체 데미지

        void Start()
        {
            Destroy(gameObject, 5f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                // 플레이어 데미지 처리
                GameManager.instance.GetWeight(damage); // 플레이어에게 데미지
                Destroy(gameObject);
            }
        }
    }
}