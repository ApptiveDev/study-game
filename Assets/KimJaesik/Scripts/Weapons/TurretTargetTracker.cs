using UnityEngine;
using System.Collections;

namespace KJS
{
    public class TurretTargetTracker : MonoBehaviour
    {
        [Header("타겟 탐색 주기")]
        public float trackInterval = 0.3f;

        [Header("최대 탐색 거리")]
        public float maxTrackingRange = 10f;

        [Header("현재 타겟 (외부 접근용)")]
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
