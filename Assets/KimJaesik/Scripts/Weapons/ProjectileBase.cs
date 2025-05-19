using UnityEngine;

namespace KJS
{
    public class ProjectileBase : MonoBehaviour
    {
        [Header("이동 및 수명")]
        public float speed = 5f;
        public float lifeTime = 3f;

        protected virtual void Start()
        {
            Destroy(gameObject, lifeTime); // 풀링 전환 시 대체 가능
        }

        protected virtual void Update()
        {
            Move();
        }

        protected virtual void Move()
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
}
