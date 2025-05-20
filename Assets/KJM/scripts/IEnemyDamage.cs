using UnityEngine;

namespace KJM
{
    public interface IEnemyDamage
    {
        void TakeDamage(float damage);

        void TakeTimeDamage(float damage);
    }

}