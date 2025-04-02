using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class FillAmount : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemy;

    private void Update()
    {
        GetComponent<Image>().fillAmount = enemy.GetHealth() / enemy.GetMaxHealth();
    }
}
