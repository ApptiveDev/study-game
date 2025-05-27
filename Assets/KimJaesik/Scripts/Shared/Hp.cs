using UnityEngine;

namespace KJS
{
    public class Hp : MonoBehaviour
    {
        [Header("체력 설정")]
        public int maxHP = 5;
        protected int currentHP;

        protected virtual void Start()
        {
            currentHP = maxHP;
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            var attack = collision.GetComponent<AttackData>();
            if (attack == null) return;

            var selfFaction = GetComponent<Faction>();
            if (selfFaction == null) return;

            if (!FactionRules.AreHostile(selfFaction.type, attack.attackerFaction))
                return;

            TakeDamage(attack.damageAmount);

            var statusReceiver = GetComponent<StatusReceiver>();
            if (statusReceiver != null && attack.statusEffect != StatusEffectType.None)
            {
                statusReceiver.ApplyStatusEffect(attack.statusEffect, attack.statusDuration);
            }
        }

        public virtual void TakeDamage(int amount)
        {
            currentHP -= amount;

            if (currentHP <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
