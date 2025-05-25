using UnityEngine;
using UnityEngine.UI;

namespace JWGR
{
    public class StoreInfo : MonoBehaviour
    {
        [SerializeField] Text moneyText;
        public int money;

        private void Start ()
        {
            moneyText = GetComponentInChildren<Text>();
        }

        private void Update ()
        {
            money = Player.money;
            moneyText.text = money.ToString() + " G";
        }
    }
}