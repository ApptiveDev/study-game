using UnityEngine;

public class SimpleLaserLineFinal : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
    public LineRenderer laserLineRenderer;
    public Transform firePoint; // 레이저 발사 시작 지점
    public float laserMaxLength = 1000f; // 레이저 최대 길이
    public Color laserColor = Color.red; // 레이저 색상
    public float laserWidth = 0.1f; // 레이저 두께

    void Start()
    {
        if (laserLineRenderer == null)
        {
            Debug.LogError("LineRenderer가 할당되지 않았습니다!");
            enabled = false;
        }
        if (firePoint == null)
        {
            Debug.LogError("Fire Point가 할당되지 않았습니다!");
            enabled = false;
        }

        // LineRenderer 초기 설정
        laserLineRenderer.enabled = false;
        laserLineRenderer.positionCount = 2; // 시작점과 끝점

        // Material 생성 및 색상, 너비 설정 (코드에서 설정)
        Material laserMat = new Material(Shader.Find("Sprites/Default"));
        laserMat.color = laserColor;
        laserLineRenderer.material = laserMat;
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 클릭했을 때
        {
            FireLaser();
        }
        else if (Input.GetMouseButtonUp(0)) // 마우스 왼쪽 버튼에서 손을 뗐을 때
        {
            StopLaser();
        }
    }

    void FireLaser()
    {
        laserLineRenderer.enabled = true;
        laserLineRenderer.SetPosition(0, firePoint.position);
        if (playerRenderer.flipX)
        {
            laserLineRenderer.SetPosition(1, -(firePoint.position + firePoint.right * laserMaxLength)); // forward 대신 right 사용!
        }
        else
        {
            laserLineRenderer.SetPosition(1, firePoint.position + firePoint.right * laserMaxLength); // forward 대신 right 사용!
        }
    }

    void StopLaser()
    {
        laserLineRenderer.enabled = false;
    }
}