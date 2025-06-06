using UnityEngine;
namespace AJH {
public class NewMonoBehaviourScript : MonoBehaviour
{
    float moveSpeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update() {
        if(Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        } 
        if(Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
    // [SerializeField] private GameObject _circle;
    // private void Update() {
    //     float time = 0f;
    //     time += Time.deltaTime;
    //     if (time > 2f) {
    //         Instantiate(_circle, transform.position, transform.rotation);
    //         time = 0f;
    //     }
    // }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Spawner : MonoBehaviour
// {
//     // 원 변수를 유니티에서 볼 수 있게 직렬화한 후, 프리팹을 참조시켜 준다.
//     [SerializeField] GameObject circleObject;

//     // 현재시간 변수
//     float curTime = 0;
    
//     //원 10개를 만든다. For문 반복 사용.
//     private void Start()
//     {
//         //for (int i = 0; i < 10; i++)
//         //{
//         //    Instantiate(circleObject);// 물체(원)를 생성한다.
//         //    circleObject.transform.position = PickRandomPosition();
//         //    circleObject.GetComponent<SpriteRenderer>().color = PickRandomColor();
//         //}
//     }

//     // 1초마다 원을 만든다.
//     private void Update()
//     {
//         curTime += Time.deltaTime;
//         if (curTime >= 1) 
//         {
//             MakeRandomCircle();
//             curTime = 0;
//         }
//     }

//     void MakeRandomCircle() // 물체(원)를 생성한다.
//     {
//         Instantiate(circleObject);
//         circleObject.transform.position = PickRandomPosition();
//         circleObject.GetComponent<SpriteRenderer>().color = PickRandomColor();
//     }

//     Vector3 PickRandomPosition() // 랜덤한 위치(벡터3)을 반환한다.
//     {
//         float x = Random.Range(-3f, 3f);
//         float y = Random.Range(-3f, 3f);

//         return new Vector3(x, y, 0);
//     }

//     Color PickRandomColor() // 랜덤한 색깔을 반환한다.
//     {
//         float r = Random.Range(0, 1f);
//         float g = Random.Range(0, 1f);
//         float b = Random.Range(0, 1f);

//         return new Color(r, g, b);
//     }
// }


}

