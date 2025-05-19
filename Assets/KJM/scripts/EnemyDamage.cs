using UnityEngine;

namespace KJM
{
    public interface EnemyDamage
    {
        void TakeDamage(float damage);

        void TakeTimeDamage(float damage);
    }

}