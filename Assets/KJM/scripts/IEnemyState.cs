using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace KJM
{
    public interface IEnemyState
    {
        public void EnterState(RangeEnemy rangeEnemy); // 상태 진입할 때 수행하는 행동
        public void ExecuteAction(); // 각 상태일 때 수행하는 행동
        public void ExitState(); // 상태 빠져나갈 때 수행하는 행동
    }

    public class MoveState : IEnemyState
    {
        RangeEnemy enemy;
        private float ATTACK_RANGE = 5;
        public void EnterState(RangeEnemy rangeEnemy)
        {
            enemy = rangeEnemy;
        }
        public void ExecuteAction()
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, Player.Instance.transform.position, 1.5f * Time.deltaTime);
        }

        public void ExitState()
        {
            if (Vector3.Distance(Player.Instance.transform.position, enemy.transform.position) <= ATTACK_RANGE)
            {
                enemy.ChangeState(new AttackState());
            }
        }

        public class AttackState : IEnemyState
        {
            RangeEnemy enemy;
            float CurrentTime = 0;
            private float ATTACK_RANGE = 5;
            public void EnterState(RangeEnemy rangeEnemy)
            {
                enemy = rangeEnemy;
            }
            public void ExecuteAction()
            {
                CurrentTime += Time.deltaTime;
                if (CurrentTime > 3f)
                {
                    enemy.SpawnCrystal();
                    CurrentTime = 0;
                }
            }

            public void ExitState()
            {
                if (Vector3.Distance(Player.Instance.transform.position, enemy.transform.position) > ATTACK_RANGE)
                {
                    enemy.ChangeState(new MoveState());
                }
            }

        }
    }
}

