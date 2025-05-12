using UnityEngine;
using System.Collections;

namespace KJS
{
    public class MissileLauncher : MonoBehaviour
    {
        public GameObject missilePrefab;
        public float castTime = 3f;

        void Start()
        {
            StartCoroutine(AutoFire());
        }

        private IEnumerator AutoFire()
        {
            while (true)
            {
                FireMissiles();
                yield return new WaitForSeconds(castTime);
            }
        }

        void FireMissiles()
        {
            Instantiate(missilePrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, -45f));
            Instantiate(missilePrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, -135f));
        }
    }
}
