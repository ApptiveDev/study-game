using System.Collections;
using UnityEngine;
//무기를 랜덤으로 선택해 일정시간이 지나면 생성한다.
namespace KJM
{
    public class WeaponSpawner : MonoBehaviour
    {
        public static WeaponSpawner Instance { get; private set; }
        [SerializeField] public GameObject[] weapons; //무기 배열
        float spawnDelay = 1.5f;
        float currentDelay = 0f;
        public int weaponCnt = 1;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); //신이 바껴도 오브젝트 유지
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
            //랜덤 선택
            int randomIndex = Random.Range(0, weapons.Length);
            GameObject weapon = weapons[randomIndex];
            for (int i = 0; i < weaponCnt; i++)
            {
                SoundManager.Instance.PlayWeaponSound(weapon.tag);
                GameObject shootWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
            }
            
        }
    }



}
