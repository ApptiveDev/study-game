using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JWGR
{
    public class arrowSpawner : MonoBehaviour
    {
        [SerializeField] GameObject arrowObject;
        public float spawnDelay = 2f;
        private ItemData itemData;

        private void Start()
        {
            itemData = arrowObject.GetComponent<ItemData>();
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (itemData != null && itemData.canSpawn)
                {
                    SoundManage.instance.PlaySFX(SoundManage.ESfx.SFX_ARROW);
                    spawnDelay = itemData.speed;
                    Instantiate(arrowObject, transform.position, Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}