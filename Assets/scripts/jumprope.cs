using UnityEngine;

public class jumprope : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1씩 회전
        transform.Rotate(0, 0, 1f);
    }
}
