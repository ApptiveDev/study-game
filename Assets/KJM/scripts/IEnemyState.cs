using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace KJM
{
    public interface IEnemyState
    {
        public void EnterState(RangeEnemy rangeEnemy); // ���� ������ �� �����ϴ� �ൿ
        public void ExecuteAction(); // �� ������ �� �����ϴ� �ൿ
        public void ExitState(); // ���� �������� �� �����ϴ� �ൿ
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

