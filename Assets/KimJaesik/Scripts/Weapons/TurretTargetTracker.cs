using UnityEngine;
using System.Collections;

namespace KJS
{
    public class TurretTargetTracker : MonoBehaviour
    {
        [Header("Ÿ�� Ž�� �ֱ�")]
        public float trackInterval = 0.3f;

        [Header("�ִ� Ž�� �Ÿ�")]
        public float maxTrackingRange = 10f;

        [Header("���� Ÿ�� (�ܺ� ���ٿ�)")]
        public Transform currentTarget;

        private Faction parentFaction;

        private void Start()
        {
            parentFaction = GetComponentInParent<Faction>();
            StartCoroutine(TrackRoutine());
        }

        private IEnumerator TrackRoutine()
        {
            while (true)
            {
                UpdateTarget();
                yield return new WaitForSeconds(trackInterval);
            }
        }

        private void UpdateTarget()
        {
            if (parentFaction == null || TargetManager.Instance == null)
            {
                currentTarget = null;
                return;
            }

            currentTarget = TargetManager.Instance.GetNearestHostileTarget(
                transform.position,
                parentFaction.type,
                maxTrackingRange
            );
        }
    }
}
