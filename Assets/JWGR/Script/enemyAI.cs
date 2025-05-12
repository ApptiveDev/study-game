using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace JWGR
{
    public class enemyAI : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject exp;
        private GameObject weapon;
        private GameObject clone;
        private Vector3 dirVector;

        public float health = 100f;
        public float speed = 1f;

        private void Start()
        {
            player = GameObject.Find("Player");
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (true)
            {
                dirVector = DirToObect(player);
                transform.position += (-dirVector.normalized * speed * Time.deltaTime);
                yield return null;
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
                if (weapon.gameObject.CompareTag("weapon")) // 충돌한 상대가 무기일 때
                {
                    health -= weapon.GetComponent<weaponInfo>().damage; // 체력을 무기의 고유 데미지만큼 감소시키는 코드
                    if (health <= 0) // 체력이 0 이하인 경우
                    {
                        clone = Instantiate(exp, transform.position, Quaternion.identity);
                        clone.GetComponent<SpriteRenderer>().sortingOrder = 6;
                        Destroy(gameObject); //오브젝트를 지운다.
                                             //collision.gameObject.SetActive(false); // 적 게임 오브젝트를 끈다.
                                             //gameObject.SetActive(false); // 본인 오브젝트도 끈다.
                    }
                    if (weapon.name != "Weapon2")
                    {
                        Destroy(collision.gameObject);
                    }
                }
                if (weapon.gameObject.CompareTag("piercingWeapon")) // 충돌한 상대가 무기일 때
                {
                    health -= weapon.GetComponent<weaponInfo>().damage; // 체력을 무기의 고유 데미지만큼 감소시키는 코드
                    if (health <= 0) // 체력이 0 이하인 경우
                    {
                        Instantiate(exp);
                        exp.GetComponent<SpriteRenderer>().sortingOrder = 6;
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