using UnityEngine;
using System.Collections;

namespace JWGR
{
    public class AutoLaser : MonoBehaviour
    {
        public SpriteRenderer playerRenderer;
        public GameObject laserPartPrefab; // 레이저 파츠 프리팹 (사각형 스프라이트)
        private GameObject laserObj;
        public GameObject firePoint; // 레이저 발사 시작 지점
        public float fireRate = 1f; // 초당 발사 횟수
        public float drawDuration = 0.3f; // 레이저가 그려지는 시간
        public float laserWidth = 5f; // 레이저의 너비 (사각형 스프라이트의 초기 Y 스케일)
        private SpriteRenderer laserRenderer;
        private SpriteRenderer FPRenderer;

        private void Start()
        {
            laserRenderer = GetComponent<SpriteRenderer>();
            FPRenderer = firePoint.GetComponent<SpriteRenderer>();
            StartCoroutine(Summon());

            if (laserPartPrefab == null)
            {
                Debug.LogError("Laser Prefab이 할당되지 않았습니다!");
                enabled = false;
            }
            if (firePoint.transform == null)
            {
                Debug.LogError("Fire Point가 할당되지 않았습니다!");
                enabled = false;
            }
        }

        private IEnumerator Summon()
        {
            while (true)
            {
                FireLaser();
                yield return new WaitForSeconds(fireRate);
            }
        }

        private void FireLaser()
        {
            laserObj = Instantiate(laserPartPrefab, firePoint.transform.position, firePoint.transform.rotation);
            laserObj.transform.transform.localScale = new Vector3(0f, laserWidth, 1f);
            float maxLength = GetLaserMaxLength(firePoint.transform.right);

            if (playerRenderer.flipX)
            {
                laserRenderer.flipX = true;
                FPRenderer.flipX = true;
                LeanTween.scaleX(laserObj, -maxLength, drawDuration).setOnComplete(() => Destroy(laserObj));
            }
            else
            {
                laserRenderer.flipX = false;
                FPRenderer.flipX = false;
                LeanTween.scaleX(laserObj, maxLength, drawDuration).setOnComplete(() => Destroy(laserObj));
            }
        }

        private float GetLaserMaxLength(Vector3 direction)
        {
            //if (Camera.main != null)
            //{
            //    Vector3 targetViewportPoint = Camera.main.ViewportToWorldPoint(new Vector3(direction.x > 0 ? 1f : 0f, 0.5f, 0f));
            //    return Vector3.Distance(firePoint.transform.position, new Vector3(targetViewportPoint.x, firePoint.transform.position.y, 0f));
            //}
            //return 100f;
            return 100f;
        }
    }
}