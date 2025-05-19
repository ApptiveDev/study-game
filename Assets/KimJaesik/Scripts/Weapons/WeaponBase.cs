using UnityEngine;
using System.Collections;

namespace KJS
{
    public class WeaponBase : MonoBehaviour
    {
        [Header("�߻�ü ����")]
        public GameObject projectilePrefab;

        [Header("�߻� �ֱ�")]
        public float castTime = 1f;
        public bool canFire = true;

        [Header("���� ���� (���ø� ����)")]
        public AttackData attackDataTemplate;

        [Header("ȿ���� ����")]
        public AudioClip fireSfx;
        public AudioSource audioSource;

        protected Faction faction;

        protected virtual void Start()
        {
            faction = GetComponentInParent<Faction>();

            if (audioSource == null && fireSfx != null)
            {
                // �ڵ����� AudioSource �߰�
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
            }

            StartCoroutine(FireRoutine());
        }

        protected virtual IEnumerator FireRoutine()
        {
            while (true)
            {
                if (canFire)
                {
                    Fire();
                }
                yield return new WaitForSeconds(castTime);
            }
        }

        protected virtual void Fire()
        {
            if (projectilePrefab == null || attackDataTemplate == null)
                return;

            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            AttackData data = projectile.GetComponent<AttackData>();
            if (data != null)
            {
                data.damageAmount = attackDataTemplate.damageAmount;
                data.statusEffect = attackDataTemplate.statusEffect;
                data.statusDuration = attackDataTemplate.statusDuration;
                data.attackerFaction = faction != null ? faction.type : FactionType.Neutral;
            }

            if (fireSfx != null && audioSource != null)
            {
                audioSource.PlayOneShot(fireSfx);
            }
        }
    }
}
