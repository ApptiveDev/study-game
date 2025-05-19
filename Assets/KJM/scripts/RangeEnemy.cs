using System.Collections;
using UnityEngine;

namespace KJM
{
    public enum EnemyState
    {
        MOVE,
        ATTACK,
        DEATH,
    }
    public class RangeEnemy : MonoBehaviour, EnemyDamage
    {
        EnemyState state;
        float CurrentTime = 0;
        private float ATTACK_RANGE = 5;
        private float check_delay = 0.4f;
        [SerializeField] private GameObject EnemyBall;
        [SerializeField] GameObject Coin;
        public float health = 50f;
       
        public void TakeDamage(float damage)
        {
            health -= damage;
        }
        public void TakeTimeDamage(float damage)
        {
            health -= damage * Time.deltaTime;
        }
        void Start()
        {
            StartCoroutine(CheckState());
                
        }

        public IEnumerator CheckState()
        {
            while (true)
            {
                if (Vector3.Distance(Player.Instance.transform.position, transform.position) <= ATTACK_RANGE)
                {
                    state = EnemyState.ATTACK;
                }
                else
                {
                    state = EnemyState.MOVE;
                }

                if (health <= 0) state = EnemyState.DEATH;

                yield return new WaitForSeconds(check_delay);
            }
        }
        private void Update()
        {
            if (state == EnemyState.MOVE)
            {
                MoveToPlayer();
            }
            else if (state == EnemyState.ATTACK)
            {
                ShootWeapon();
            }
            else if (state == EnemyState.DEATH) //죽으면 코인 반환
            {
                Vector3 deathPosition = transform.position;
                Destroy(gameObject); // 적 게임 오브젝트를 지운다.
                Instantiate(Coin, deathPosition, Quaternion.identity);
            }
        }

        void MoveToPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, 1.5f * Time.deltaTime);
        }

        void ShootWeapon()
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime > 3f)
            {
                Instantiate(EnemyBall,transform.position, Quaternion.identity);
                CurrentTime = 0;
            }
        }
    }

}

