using AJH;
using UnityEngine;
namespace AJH
{
    // 몬스터의 상태를 정의하는 인터페이스
    public interface IEnemyState
    {
        public void EnterState(RangeEnemyAI enemy);
        public void ExecuteState();
        public void ExitState();
    }

    public class MoveState : IEnemyState
    {
        private RangeEnemyAI enemy;

        public void EnterState(RangeEnemyAI enemy)
        {
            this.enemy = enemy;
        }

        public void ExecuteState()
        {
            enemy.ChasePlayer();
        }

        public void ExitState()
        {
            if (enemy.IsClose())
            {
                enemy.ChangeState(new AttackState()); 
            }
        }
        // 상태 패턴을 사용하여 몬스터의 행동을 관리하기 위한 인터페이스
    }
    

    public class AttackState : IEnemyState
    {
        private RangeEnemyAI enemy;
        private float stateTimer = 0f; // 상태 지속 시간


        public void EnterState(RangeEnemyAI enemy)
        {
            this.enemy = enemy;
            stateTimer = 0f; // 상태 진입 시 타이머 초기화
            if (enemy.attackCoroutine == null)
            {
                enemy.attackCoroutine = enemy.StartCoroutine(enemy.AttackPlayer());
            }
        }

        public void ExecuteState()
        {
            stateTimer += Time.deltaTime;
        }

        public void ExitState()
        {
            if (enemy.attackCoroutine != null)
            {
                enemy.StopCoroutine(enemy.attackCoroutine);
                enemy.attackCoroutine = null;
            }


            if (!enemy.IsClose() && stateTimer >= 2f)
            {
                enemy.ChangeState(new MoveState());
            }
        }
    }
}


