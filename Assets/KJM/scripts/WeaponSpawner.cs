using System.Collections;
using UnityEngine;
//���⸦ �������� ������ �����ð��� ������ �����Ѵ�.
namespace KJM
{
    public class WeaponSpawner : MonoBehaviour
    {
        public static WeaponSpawner Instance { get; private set; }
        [SerializeField] public GameObject[] weapons; //���� �迭
        float spawnDelay = 1.5f;
        float currentDelay = 0f;
        public int weaponCnt = 1;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); //���� �ٲ��� ������Ʈ ����
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
            //���� ����
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
