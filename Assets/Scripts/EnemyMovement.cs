using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject target;
    private float speed = 1.0f;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction = direction / direction.magnitude;
        transform.position += direction * speed * Time.deltaTime;
    }
}
