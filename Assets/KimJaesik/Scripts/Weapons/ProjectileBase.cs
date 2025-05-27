using UnityEngine;

namespace KJS
{
    public class ProjectileBase : MonoBehaviour
    {
        [Header("�̵� �� ����")]
        public float speed = 5f;
        public float lifeTime = 3f;

        protected virtual void Start()
        {
            Destroy(gameObject, lifeTime); // Ǯ�� ��ȯ �� ��ü ����
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
