using UnityEngine;

namespace KJS
{
    public class PlayerHp : Hp
    {
        [SerializeField] private PlayerExp exp;

        protected override void Start()
        {
            base.Start();
            if (exp == null)
            {
                exp = GetComponent<PlayerExp>();
            }
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            // 경험치 오브젝트 처리 위임
            if (collision.CompareTag("ExpObj"))
            {
                exp?.ProcessExpPickup(collision);
                return;
            }

            // 공격 처리 (공통)
            base.OnTriggerEnter2D(collision);
        }

        protected override void Die()
        {
            var sr = GetComponent<SpriteRenderer>();
            if (sr) sr.enabled = false;

            var col = GetComponent<Collider2D>();
            if (col) col.enabled = false;

            var rb = GetComponent<Rigidbody2D>();
            if (rb) rb.simulated = false;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            Debug.Log("플레이어 사망 처리 완료");
        }
    }
}
