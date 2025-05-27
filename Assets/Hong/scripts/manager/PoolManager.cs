using UnityEngine;
using System.Collections.Generic;
namespace AJH{
    public class PoolManager : MonoBehaviour
    {

        public static PoolManager Instance;
        int poolCount = 20;
        [SerializeField] private GameObject poolObject;
        [SerializeField] List<GameObject> poolObjectList = new List<GameObject>();


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            for (int i = 0; i < poolCount; i++)
            {
                GameObject pooledObject = Instantiate(poolObject, transform);
                pooledObject.SetActive(false);
                poolObjectList.Add(pooledObject);
            }
        }


        public GameObject GetObject()
        {
            GameObject pooledObject = poolObjectList[0];
            pooledObject.SetActive(true);
            pooledObject.transform.SetParent(null);
            poolObjectList.RemoveAt(0);
            return pooledObject;

        }
        // public GameObject[] prefabs;

        // List<GameObject>[] pools;    


        // public GameObject Get(int index) 
        // {
        //     GameObject select = null;

        //     foreach (GameObject item in pools[index])
        //     {
        //         if (!item.activeSelf)
        //         {
        //             select = item;
        //             select.SetActive(true);
        //             break;
        //         }
        //     }

        //     if (!select) {
        //         select = Instantiate(prefabs[index], transform);
        //         pools[index].Add(select);
        //     }
        //     return select;
        // }

    }
}

