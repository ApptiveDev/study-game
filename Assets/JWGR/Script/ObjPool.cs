using System.Collections.Generic;
using UnityEngine;

namespace JWGR
{
    public class ObjPool : MonoBehaviour
    {
        public static ObjPool instance; //싱글톤

        [Header("Pool Settings")]
        [SerializeField] private GameObject arrowPrefab; // 풀링할 화살 프리팹
        [SerializeField] private int initialPoolSize = 10; // 초기 풀 크기

        Queue<GameObject> poolObjectQueue = new Queue<GameObject>(); // 오브젝트를 담는 풀

        private void Awake()
        {
            // 싱글턴 초기화
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                // 이미 인스턴스가 존재하면 새로 생성된 자신을 파괴 (중복 방지)
                Destroy(gameObject);
                return;
            }

            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject arrow = Instantiate(arrowPrefab, transform); // ArrowPool 오브젝트의 자식으로 생성하여 Hierarchy를 깔끔하게 유지
                arrow.SetActive(false); // 비활성화 상태로 생성
                poolObjectQueue.Enqueue(arrow); // 큐에 추가
            }
        }

        public GameObject GetObject()
        {
            GameObject arrowSpawned;

            if (poolObjectQueue.Count > 0)
            {
                arrowSpawned = poolObjectQueue.Dequeue(); // 큐에서 화살을 꺼냄
            }
            else
            {
                // 풀이 비어있으면 새로 생성 (필요에 따라 풀 크기 확장)
                arrowSpawned = Instantiate(arrowPrefab, transform);
            }

            // 가져온 화살은 호출하는 쪽에서 위치, 회전, 활성화 등을 설정합니다.
            return arrowSpawned;
        }

        public void ReturnObject(GameObject obj)
        {
            if (obj == null) return;

            obj.SetActive(false); // 화살 비활성화
            poolObjectQueue.Enqueue(obj); // 큐에 다시 추가
        }
    }
}