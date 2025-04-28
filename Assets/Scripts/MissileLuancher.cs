using UnityEngine;

public class MissileLuancher : MonoBehaviour
{
    public GameObject missilePrefab;
    public float castTime = 3f;
    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= castTime)
        {
            FireMissiles();
            spawnTimer = 0f;
        }
    }
    void FireMissiles()
    {
        Instantiate(missilePrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, -45f));
        Instantiate(missilePrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, -135f));
    }
}
