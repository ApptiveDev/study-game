using System.Collections.Generic;
using UnityEngine;
namespace AJH{


    [RequireComponent(typeof(Collider2D))]
    public class jumprope : MonoBehaviour
    {
        [Header("회전 속도 (도/초)")]
        [SerializeField] private float rotationSpeed = 360f;
        [Header("틱당 데미지")]
        [SerializeField] public float damagePerTick = 1;
        [Header("데미지 간격 (초)")]
        [SerializeField] public float tickInterval = 1f;
        [Header("넉백 세기")]
        [SerializeField] private float bounceStrength = 2f;

        // 충돌 중인 적별로 "다음 데미지 시각" 저장
        private Dictionary<IDamageable, float> _nextDamageTime = new Dictionary<IDamageable, float>();

        void Update()
        {
            // 줄넘기 회전
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.GetComponent<IDamageable>();
            if (enemy == null) return;

            DealDamageAndBounce(enemy);
            _nextDamageTime[enemy] = Time.time + tickInterval;
        }

        void OnTriggerStay2D(Collider2D other)
        {
            var enemy = other.GetComponent<IDamageable>();
            if (enemy == null) return;

            // 틱 간격이 지났으면 다시 피해와 넉백
            if (Time.time >= _nextDamageTime[enemy])
            {
                DealDamageAndBounce(enemy);
                _nextDamageTime[enemy] = Time.time + tickInterval;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            var enemy = other.GetComponent<IDamageable>();
            if (enemy != null)
                _nextDamageTime.Remove(enemy);
        }

        private void DealDamageAndBounce(IDamageable enemy)
        {
            // 데미지 적용
            enemy.TakeDamage(damagePerTick);

            // 넉백 적용: 방향 계산 후 enemyAI 내부로 전달
            Vector2 dir = (enemy.Transform.position - transform.position).normalized;
            enemy.AddKnockback(dir * bounceStrength);
        }
    }

}