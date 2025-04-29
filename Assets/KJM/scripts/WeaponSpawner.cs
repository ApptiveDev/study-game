using System.Collections;
using UnityEngine;
//���⸦ �������� ������ �����ð��� ������ �����Ѵ�.
public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] weapons; //���� �迭
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
        //���� ����
        int randomIndex = Random.Range(0, weapons.Length);
        GameObject weapon = weapons[randomIndex];

        GameObject shootWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
    }
}


