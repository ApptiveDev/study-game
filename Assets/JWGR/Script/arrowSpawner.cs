using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JWGR
{
    public class arrowSpawner : MonoBehaviour
    {
        [SerializeField] GameObject arrowObject;
        public float spawnDelay = 2f;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (arrowObject.GetComponent<ItemData>().canSpawn)
                {
                    gameObject.SetActive(true);
                    SoundManage.instance.PlaySFX(SoundManage.ESfx.SFX_ARROW);

                    spawnDelay = arrowObject.GetComponent<ItemData>().speed;
                    Instantiate(arrowObject, transform.position, Quaternion.identity);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}