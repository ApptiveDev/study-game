using UnityEngine;

public class EnergyWaveCannon : MonoBehaviour
{
    public GameObject energyWavePrefab;

    public float castTime = 5f;
    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= castTime)
        {
            Fire();
            spawnTimer = 0f;
        }
    }

    void Fire()
    {
        Instantiate(energyWavePrefab, transform.position, transform.rotation);
    }
}
