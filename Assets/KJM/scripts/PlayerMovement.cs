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

        //�̵��Ҷ� -> �޸��� �ִϸ��̼�
        bool isRunning = (h != 0 || v != 0);
        animator.SetBool("isRunning", isRunning);//���ϸ����� �ȿ� isRunning Bool �Ķ���Ϳ� ���� �ִ´�.
        if (h > 0) transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f); //�¿� ����
        else if (h < 0) transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        Vector3 direction = new Vector3(h, v, 0);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}