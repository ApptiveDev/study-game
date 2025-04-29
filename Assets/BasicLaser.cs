using UnityEngine;

public class BasicLaser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float length = 5f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer 컴포넌트가 없습니다!");
            enabled = false;
            return;
        }

        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.right * length);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}