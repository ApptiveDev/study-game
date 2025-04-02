using UnityEngine;
using UnityEngine.UIElements;

public class Throw : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private float flightTime = 1f;
    private Rigidbody2D rb;
    private Vector3 target;

    public void SetTargetTransform(Transform target)
    {
        this.target = target.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ThrowToTarget();
    }

    private void Update()
    {
        if ((target - transform.position).magnitude <= 0.1f)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void ThrowToTarget()
    {
        while (target == null) ;
        Vector3 startPosition = transform.position;
        Vector3 displacement = target - startPosition;

        float vx = displacement.x / flightTime;
        float vy = (displacement.y - 0.5f * Physics2D.gravity.y * flightTime * flightTime) / flightTime;

        rb.linearVelocity = new Vector3(vx, vy);
    }
}
