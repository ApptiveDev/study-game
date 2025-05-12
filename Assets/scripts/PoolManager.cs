using UnityEngine;
using System.Collections.Generic;
namespace AJH{
    public class PoolManager : MonoBehaviour
    {
        public GameObject[] prefabs;

        List<GameObject>[] pools;    
    

        public GameObject Get(int index) 
        {
            GameObject select = null;

            foreach (GameObject item in pools[index])
            {
                if (!item.activeSelf)
                {
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }

            if (!select) {
                select = Instantiate(prefabs[index], transform);
                pools[index].Add(select);
            }
            return select;
        }

    }
}

