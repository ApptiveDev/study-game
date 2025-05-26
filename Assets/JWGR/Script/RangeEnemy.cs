using UnityEngine;
using System.Collections;
using JWGR;
using UnityEngine.Scripting.APIUpdating;
using Unity.VisualScripting;

namespace JWGR
{
    public class RangeEnemy : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject exp;
        [SerializeField] EnemyState state;
        [SerializeField] GameObject arrowObject;
        private GameObject weapon;
        private GameObject clone;
        private enemyInfo info;
        public float checkDelay = 0.2f;
        public float spawnDelay = 2f;
        public float currentDelay = 0f;
        public float attackRange = 10f;
        public float HP = 100f;
        public float speed = 1f;
        private Vector3 dirVector;

        public enum EnemyState
        {
            Move,
            Attack,
        }

        private void Start()
        {
            player = GameObject.Find("Player");
            info = GetComponent<enemyInfo>();
            spawnDelay = arrowObject.GetComponent<ItemData>().speed;
            StartCoroutine(ChangeState());
        }

        public IEnumerator ChangeState()
        {
            while (true)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    state = EnemyState.Attack;
                }
                else
                {
                    state = EnemyState.Move;
                }
                yield return new WaitForSeconds(checkDelay);
            }
        }

        private void Update()
        {
            if (state == EnemyState.Attack)
            {
                Attack();
            }
            else if (state == EnemyState.Move)
            {
                Move();
            }
        }

        public void Move()
        {
            dirVector = DirToObect(player);
            transform.position += (-dirVector.normalized * speed * Time.deltaTime);
        }

        public void Attack()
        {
            //매 프레임 시간을 잰다.
            currentDelay += Time.deltaTime;

            //스폰 시간이 되었을 때
            if (currentDelay >= spawnDelay)
            {
                //화살을 생성한다.
                Instantiate(arrowObject, transform.position, Quaternion.identity);
                currentDelay = 0f; // 시간을 0초로 만든다.
            }
        }

        private Vector3 DirToObect(GameObject player)
        {
            Vector3 direction = new Vector3(
                    transform.position.x - player.transform.position.x,
                    transform.position.y - player.transform.position.y, 0);
            return direction;
        }

        private void OnTriggerEnter2D(Collider2D collision) // 충돌했을 때
        {
            if (collision.gameObject != null)
            {
                weapon = collision.gameObject;
                if (weapon.gameObject.GetComponent<SpriteRenderer>().enabled)
                {
                    if (weapon.gameObject.CompareTag("weapon")) // 충돌한 상대가 무기일 때
                    {
                        info.HP -= weapon.GetComponent<ItemData>().damage; // 체력을 무기의 고유 데미지만큼 감소시키는 코드
                        if (info.HP <= 0) // 체력이 0 이하인 경우
                        {
                            clone = Instantiate(exp, transform.position, Quaternion.identity);
                            clone.GetComponent<SpriteRenderer>().sortingOrder = 6;
                            EventManage.countKill += 1;
                            Destroy(gameObject); //오브젝트를 지운다.
                                                 //collision.gameObject.SetActive(false); // 적 게임 오브젝트를 끈다.
                                                 //gameObject.SetActive(false); // 본인 오브젝트도 끈다.
                        }
                        if (weapon.name != "Sickle")
                        {
                            Destroy(collision.gameObject);
                        }
                    }
                    if (weapon.gameObject.CompareTag("piercingWeapon")) // 충돌한 상대가 무기일 때
                    {
                        info.HP -= weapon.GetComponent<ItemData>().damage; // 체력을 무기의 고유 데미지만큼 감소시키는 코드
                        if (info.HP <= 0) // 체력이 0 이하인 경우
                        {
                            Instantiate(exp);
                            exp.GetComponent<SpriteRenderer>().sortingOrder = 6;
                        }
                    }
                }
            }
            else
            {
                Debug.Log(collision);
                return;
            }
        }
    }
}
