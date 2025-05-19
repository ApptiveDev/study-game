using UnityEngine;

namespace KJS
{
    public enum StatusEffectType
    {
        None,
        Burn,
        Slow,
        Stun
    }

    public class AttackData : MonoBehaviour
    {
        [Tooltip("공격이 가하는 피해량")]
        public int damageAmount = 1;

        [Tooltip("공격자의 팩션")]
        public FactionType attackerFaction = FactionType.Player;

        [Header("상태이상 옵션")]
        public StatusEffectType statusEffect = StatusEffectType.None;

        [Tooltip("상태이상 지속 시간")]
        public float statusDuration = 2f;
    }
}

