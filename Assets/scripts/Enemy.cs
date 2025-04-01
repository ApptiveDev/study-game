using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20f;
    float moveDistance = 0.003f;
    float enemySpeed;

    public void SetSpeed()
    {
        float time = Time.time;
        if (time <= 30)
        {
            enemySpeed = 1f + Time.time / 10;
        }
        else enemySpeed = 4f;
    }

    private void Start()
    {
        SetSpeed();
    }

    private void Update()
    {
     
        
    }
}