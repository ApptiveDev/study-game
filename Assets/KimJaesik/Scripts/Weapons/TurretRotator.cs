using UnityEngine;

namespace KJS
{
    public class TurretRotator : MonoBehaviour
    {
        [Header("회전 속도")]
        public float rotateSpeed = 5f;

        [Header("타겟 트래커")]
        public TurretTargetTracker tracker;

        private void Update()
        {
            if (tracker == null || tracker.currentTarget == null)
                return;

            RotateTowards(tracker.currentTarget.position);
        }

        private void RotateTowards(Vector3 targetPosition)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;

            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}
