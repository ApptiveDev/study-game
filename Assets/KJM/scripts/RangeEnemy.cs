using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

namespace KJM
{
/*    public enum EnemyState
    {
        MOVE,
        ATTACK,
        DEATH,
    }*/
    public class RangeEnemy : MonoBehaviour, IEnemyDamage
    {
/*        EnemyState state;*/
/*        float CurrentTime = 0;
        private float ATTACK_RANGE = 5;*/
/*        private float check_delay = 0.4f;*/
        [SerializeField] private GameObject EnemyBall;
        [SerializeField] GameObject Coin;
        public float health = 50f;
        public IEnemyState curState;

        public void TakeDamage(float damage)
        {
            health -= damage;
        }
        public void TakeTimeDamage(float damage)
        {
            health -= damage * Time.deltaTime;
        }

        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        public Vector3 EnemyPosition()
        {
            return transform.position;
        }
        void Start()
        {
            curState = new MoveState();
            curState.EnterState(this);
           /* StartCoroutine(CheckState());*/
                
        }
        public void ChangeState(IEnemyState newState)
        {
            newState.EnterState(this);
            curState = newState;
        }
       /* public IEnumerator CheckState()
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
        }*/
        private void Update()
        {
            curState.ExecuteAction();
            curState.ExitState();
            if (health <= 0)
            {
                Vector3 deathPosition = transform.position;
                Destroy(gameObject); // 적 게임 오브젝트를 지운다.
                Instantiate(Coin, deathPosition, Quaternion.identity);
            }
           /* if (state == EnemyState.MOVE)
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
            }*/
        }

       /* void MoveToPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, 1.5f * Time.deltaTime);
        }*/

      /*  void ShootWeapon()
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime > 3f)
            {
                Instantiate(EnemyBall,transform.position, Quaternion.identity);
                CurrentTime = 0;
            }
        }*/
        public void SpawnCrystal()
        {
            Instantiate(EnemyBall, transform.position, Quaternion.identity);
        }
 
    }

}

