using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float thrustForce = 5f;
    public float turnSpeed = 200f;
    public float maxSpeed = 8f;

    Rigidbody2D rb;

    [SerializeField] GameObject Spawned;
    float curTime = 0;
    public float spwanSec = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        transform.Rotate(0, 0, -turnInput * turnSpeed * Time.deltaTime);

        rb.AddForce(transform.up * moveInput * thrustForce);

        curTime += Time.deltaTime;
        if (curTime >= spwanSec)
        {
            GameObject newObj = Instantiate(Spawned);

            Vector3 spawnPos = PickRandomPosition();
            newObj.transform.position = spawnPos;
            newObj.transform.rotation = GetRotation(spawnPos);
            curTime = 0;
        }

        Vector3 PickRandomPosition()
        {
            float x = transform.position.x + Random.Range(-1f, 1f);
            float y = transform.position.y + Random.Range(-1f, 1f);

            return new Vector3(x, y, 0);
        }

        Quaternion GetRotation(Vector3 spawnPos)//스포너 밖을 향하도록 회전
        {
            Vector3 toSpawner = transform.position - spawnPos;
            float angle = Mathf.Atan2(toSpawner.y, toSpawner.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, angle + 90);
        }
    }
    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

}