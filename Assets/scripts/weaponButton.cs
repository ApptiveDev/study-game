using UnityEngine;
using UnityEngine.UI;
namespace AJH{
    public class weaponButton : MonoBehaviour
    {
        public WeaponData data;
        public int level;

        Text textLevel;
        Transform player;

        void Awake()
        {
            Text[] texts = GetComponentsInChildren<Text>();
            textLevel = texts[0];
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.transform;
        
        }

        void LateUpdate()
        {
            textLevel.text = $"Lv.{level+1}";
        }

        public void OnClick()
        {
            switch (data.itemType) {
                case WeaponData.ItemType.Rope :
                    if (level == 0) {
                        Instantiate(data.projectile, player.position, Quaternion.identity, player);
                    }
                    break;
                case WeaponData.ItemType.Axe:
                    if (level == 0) {
                        Instantiate(data.projectile, player.position, Quaternion.identity, player);
                    }
                    break;
                case WeaponData.ItemType.Range:
                    if (level == 0) {
                        Instantiate(data.projectile, player.position, Quaternion.identity, player);
                    }
                    break;
            }
            level++;
            if (level == data.damages.Length) {
                GetComponent<Button>().interactable = false;
            }
        }
    }

}
