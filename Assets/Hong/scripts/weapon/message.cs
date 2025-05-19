using UnityEngine;
namespace AJH{

    public class message : MonoBehaviour
    {
        [Header("데미지")]
        public float damage = 5;


        private Collider2D _myCollider;
        private Collider2D _playerCollider;
        void Awake()
        {
            _myCollider = GetComponent<Collider2D>();

            var _player = player.Instance;
            if (_player != null)
                _playerCollider = _player.GetComponent<Collider2D>();

            if (_playerCollider != null)
                Physics2D.IgnoreCollision(_myCollider, _playerCollider);

            
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            IDamageable damageable = col.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage); // 데미지 적용
                Destroy(gameObject); // 오브젝트 삭제
            }
        }
    }
}