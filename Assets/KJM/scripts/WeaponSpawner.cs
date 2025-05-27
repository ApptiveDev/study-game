using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
//���⸦ �������� ������ �����ð��� ������ �����Ѵ�.
namespace KJM
{
    public class WeaponSpawner : MonoBehaviour
    {
        public static WeaponSpawner Instance { get; private set; }
        [SerializeField] public GameObject[] weapons; //���� �迭
        public List<int> weaponCnts = new List<int> { 1, 2, 1 };  //�� ������ �߻� ���� ����.
        float spawnDelay = 1.5f;
        float currentDelay = 0f;
        public int weaponCnt;
        public int randomIndex;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                /*DontDestroyOnLoad(gameObject); //���� �ٲ��� ������Ʈ ����*/
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
            Debug.Log("ShootWeapon �����");
            //���� ����
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
