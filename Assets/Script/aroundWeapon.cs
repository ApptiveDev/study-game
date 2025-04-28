using UnityEngine;

public class aroundWeapon : MonoBehaviour
{
    public GameObject player;
    public float aroundSpeed = 100f;
    public float rotateSpeed = 400f;
    public float radius = 10f;
    private Vector3 dirVector = Vector3.zero;

    private void Awake()
    {
        transform.position = player.transform.position + new Vector3(radius, 0, 0);
    }

    private void Update()
    {
        AroundObject();
        transform.Rotate(new Vector3(0, 0, -1f * rotateSpeed * Time.deltaTime));
        dirVector = DirToObect(player);
        //if (Vector3.Magnitude(dirVector) > radius)
        //{
        //    transform.position += (-dirVector.normalized * playerMove.moveSpeed * Time.deltaTime);
        //}
        //else if (Vector3.Magnitude(dirVector) < radius)
        //{
        //    transform.position += (dirVector.normalized * playerMove.moveSpeed * Time.deltaTime);
        //}
    }

    void AroundObject()
    {
        transform.RotateAround(player.transform.position, Vector3.forward, aroundSpeed * Time.deltaTime);
    }
    // RotateAround(Vector3 point, Vector3 axis, float angle)

    Vector3 DirToObect(GameObject player)
    {
        Vector3 direction = new Vector3(
                transform.position.x - player.transform.position.x,
                transform.position.y - player.transform.position.y, 0);
        return direction;
    }
}


