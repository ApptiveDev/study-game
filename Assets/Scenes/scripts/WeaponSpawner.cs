using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] weapons; //무기 배열
    float spawnDelay = 2f;
    float currentDelay = 0f;

    void Update()
    {
        currentDelay += Time.deltaTime;
        if (currentDelay >= spawnDelay)
        {
            ShootWeapon();
            currentDelay = 0f;
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


