using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 4f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(h, v, 0);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
