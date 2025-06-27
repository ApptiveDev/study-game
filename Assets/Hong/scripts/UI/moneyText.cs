using UnityEngine;
using UnityEngine.UI;
namespace AJH
{
    public class moneyText : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private Text money;


        // Update is called once per frame
        public void updateMoneyText()
        {
            money.text = $"보유잔액 : {GameManager.instance.totalMoney}\\";
        }
    }
}
