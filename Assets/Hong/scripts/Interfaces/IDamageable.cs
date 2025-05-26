using System.Collections;
using UnityEngine;

namespace AJH
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        void AddKnockback(Vector2 force);
        Transform Transform { get; }
    }
}