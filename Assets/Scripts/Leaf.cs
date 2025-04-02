using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float lifeTime = 0.1f;
    [SerializeField] private Vector3 direction;
    private float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime)
        {
            Destroy(gameObject);
        }

        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
