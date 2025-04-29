using System.Collections;
using UnityEngine;
//무기를 랜덤으로 선택해 일정시간이 지나면 생성한다.
public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] weapons; //무기 배열
    float spawnDelay = 1.5f;
    float currentDelay = 0f;

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

        GameObject shootWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
    }
}


