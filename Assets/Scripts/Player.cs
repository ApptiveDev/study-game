using UnityEngine;
using UnityEngine.SceneManagement;

namespace KHJ
{
    
}
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    private float speed = 3.5f;
    public float hp = 10f;

    [SerializeField] private GameObject bulletPrefab;
    private float bulletSpeed = 10f;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.position += Vector3.up * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
        if (hp <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Time.timeScale = 0;
        }
    }

    private void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        Vector2 direction = (mouseWorldPos - transform.position).normalized;
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
    }
}