using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class arrow : MonoBehaviour
{
    private GameObject target; // 타겟의 게임 오브젝트
    public GameObject player;
    private Vector3 moveDir; // 이동 방향 벡터
    private Vector3 rotateDir;
    public float moveSpeed = 3f; // 화살의 이동 속도
    private float damage = 10f; // 화살의 데미지

    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 7;
        player = GameObject.Find("Player");
        transform.position = player.transform.position;
        enemyAI enemy = FindObjectOfType<enemyAI>();
        if (enemy != null)
        {
            target = enemy.gameObject; // 타겟을 적의 오브젝트로 설정
            moveDir = target.transform.position - transform.position; // 이동 방향 벡터를 계산
            moveDir.Normalize(); // 이동 방향 벡터 정규화
        }
    }

    private void Update()
    {
        if (target == null) // 타겟이 없다면, 화살을 지운다.
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

        //rotateDir = target.transform.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(rotateDir).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime; // 화살을 진행방향 만큼 이동시킨다.
                                                                    // 타겟 방향으로 회전함
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, -(CalculateAngle(transform.position, target.transform.position)));
    }

    //private void OnTriggerEnter2D(Collider2D collision) // 충돌했을 때
    //{
    //    Debug.Log("충돌한 오브젝트: " + collision.gameObject.name);
    //    enemyAI enemy = collision.GetComponent<enemyAI>(); // 적의 Enemy 스크립트를 참조한다.
    //    if (enemy.gameObject == target) // 충돌한 상대가 내가 목표하는 적일 때,
    //    {
    //        enemy.health -= damage; // 충돌한 적의 체력을 데미지만큼 감소시키는 코드
    //        if (enemy.health <= 0) // 적 체력이 0 이하인 경우
    //        {
    //            Destroy(collision.gameObject); // 적 게임 오브젝트를 지운다.
    //             // 적 게임 오브젝트를 지운다.
    //            //collision.gameObject.SetActive(false); // 적 게임 오브젝트를 끈다.
    //            //gameObject.SetActive(false); // 본인 오브젝트도 끈다.
    //        }
    //        Destroy(gameObject);
    //    }

    //}

    public static float CalculateAngle(Vector2 currentObjectPosition, Vector2 targetObjectPosition)
    {
        // 두 점 간의 차이를 계산
        Vector2 direction = targetObjectPosition - currentObjectPosition;

        // Atan2 함수를 사용하여 아크탄젠트 값을 계산
        float radians = Mathf.Atan2(direction.x, direction.y);

        // 라디안 값을 각도로 변환
        float degrees = radians * Mathf.Rad2Deg;

        // 결과 각도가 음수인 경우 360을 더하여 양수로 변환
        if (degrees < 0)
        {
            degrees += 360;
        }
        return degrees;
    }
}
