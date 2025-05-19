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
        [Tooltip("������ ���ϴ� ���ط�")]
        public int damageAmount = 1;

        [Tooltip("�������� �Ѽ�")]
        public FactionType attackerFaction = FactionType.Player;

        [Header("�����̻� �ɼ�")]
        public StatusEffectType statusEffect = StatusEffectType.None;

        [Tooltip("�����̻� ���� �ð�")]
        public float statusDuration = 2f;
    }
}

