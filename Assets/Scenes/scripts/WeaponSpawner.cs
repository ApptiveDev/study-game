using UnityEngine;
//���⸦ �������� ������ �����ð��� ������ �����Ѵ�.
public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] weapons; //���� �迭
    float spawnDelay = 1.5f;
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
        //���� ����
        int randomIndex = Random.Range(0, weapons.Length);
        GameObject weapon = weapons[randomIndex];

        GameObject shootWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
    }
}


