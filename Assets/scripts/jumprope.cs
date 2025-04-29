using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class jumprope : MonoBehaviour
{
    [Header("회전 속도 (도/초)")]
    [SerializeField] private float rotationSpeed = 360f;
    [Header("틱당 데미지")]
    [SerializeField] private int damagePerTick = 1;
    [Header("데미지 간격 (초)")]
    [SerializeField] private float tickInterval = 1f;
    [Header("넉백 세기")]
    [SerializeField] private float bounceStrength = 2f;

    // 충돌 중인 적별로 "다음 데미지 시각" 저장
    private Dictionary<enemyAI, float> _nextDamageTime = new Dictionary<enemyAI, float>();

    void Update()
    {
        // 줄넘기 회전
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<enemyAI>();
        if (enemy == null) return;

        DealDamageAndBounce(enemy);
        _nextDamageTime[enemy] = Time.time + tickInterval;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var enemy = other.GetComponent<enemyAI>();
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
        var enemy = other.GetComponent<enemyAI>();
        if (enemy != null)
            _nextDamageTime.Remove(enemy);
    }

    private void DealDamageAndBounce(enemyAI enemy)
    {
        // 데미지 적용
        enemy.health -= damagePerTick;
        if (enemy.health <= 0f)
        {
            Destroy(enemy.gameObject);
            _nextDamageTime.Remove(enemy);
            return;
        }

        // 넉백 적용: 방향 계산 후 enemyAI 내부로 전달
        Vector2 dir = (enemy.transform.position - transform.position).normalized;
        enemy.AddKnockback(dir * bounceStrength);
    }
}
