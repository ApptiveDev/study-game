using UnityEngine;
using System.Collections;

namespace KJS
{
    public class EnergyWaveCannon : MonoBehaviour
    {
        public GameObject energyWavePrefab;

        public float castTime = 5f;

        private void Start()
        {
            StartCoroutine(AutoFire());
        }

        void Update()
        {

        }

        private IEnumerator AutoFire()
        {
            while (true)
            {
                Fire();
                yield return new WaitForSeconds(castTime);
            }
        }

        void Fire()
        {
            Instantiate(energyWavePrefab, transform.position, transform.rotation);
        }
    }
}
