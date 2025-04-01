using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] GameObject arrowObject;

    float spawnDelay = 2f;

    float currentDelay = 0f;

    private void Update()
    {
        //�� ������ �ð��� ���.
        currentDelay += Time.deltaTime;

        //���� �ð��� �Ǿ��� ��
        if (currentDelay >= spawnDelay)
        {
            //ȭ���� �����Ѵ�.
            Instantiate(arrowObject, transform.position, Quaternion.identity);
            currentDelay = 0f; // �ð��� 0�ʷ� �����.
        }
    }
}
