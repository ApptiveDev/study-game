using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
//무기를 랜덤으로 선택해 일정시간이 지나면 생성한다.
namespace KJM
{
    public class WeaponSpawner : MonoBehaviour
    {
        public static WeaponSpawner Instance { get; private set; }
        [SerializeField] public GameObject[] weapons; //무기 배열
        public List<int> weaponCnts = new List<int> { 1, 2, 1 };  //각 무기의 발사 개수 지정.
        float spawnDelay = 1.5f;
        float currentDelay = 0f;
        public int weaponCnt;
        public int randomIndex;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                /*DontDestroyOnLoad(gameObject); //신이 바껴도 오브젝트 유지*/
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            StartCoroutine(ShootWeapon2());
        }
        private IEnumerator ShootWeapon2()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnDelay);
                ShootWeapon();
            }
        }
        void ShootWeapon()
        {
            Debug.Log("ShootWeapon 실행됨");
            //랜덤 선택
            randomIndex = Random.Range(0, weapons.Length);
            GameObject weapon = weapons[randomIndex];
            weaponCnt = weaponCnts[randomIndex];
            for (int i = 0; i < weaponCnt; i++)
            {
                SoundManager.Instance.PlayWeaponSound(weapon.tag);
                GameObject shootWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
            }
            
        }
    }



}
