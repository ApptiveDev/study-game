using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{   
    public GameObject player;
    private Vector3 dirVector;

    public float speed = 1f;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        dirVector = DirToObect(player);
        transform.position += (-dirVector.normalized * speed * Time.deltaTime);
    }

    Vector3 DirToObect(GameObject player)
    {
        Vector3 direction = new Vector3(
                transform.position.x - player.transform.position.x,
                transform.position.y - player.transform.position.y, 0);
        return direction;
    }
}
