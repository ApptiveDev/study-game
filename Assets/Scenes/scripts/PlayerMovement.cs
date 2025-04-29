using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 4f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();       
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //이동할때 -> 달리기 애니메이션
        bool isRunning = (h != 0 || v != 0);
        animator.SetBool("isRunning", isRunning);//에니메이터 안에 isRunning Bool 파라미터에 값을 넣는다.
        if (h > 0) transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f); //좌우 반전
        else if (h < 0) transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        Vector3 direction = new Vector3(h, v, 0);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}