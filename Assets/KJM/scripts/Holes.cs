using UnityEngine;

namespace KJM
{
    public class Holes : MonoBehaviour
    {
        public float duration = 2f; //Ȧ�� 2�ʰ� �����ȴ�.
        void Start()
        {
            Destroy(gameObject, duration);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                Destroy(enemy); // ������ holde �ȿ� ���� ���� �Ҹ��Ѵ�.
            }
        }
    }

}
