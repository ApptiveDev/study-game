using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
namespace AJH{
    public class weaponButton : MonoBehaviour
    {
        public WeaponData data;
        public GameObject weapon;
        
        public int level;

        Text textLevel;
        Text textDiscription;
        Transform player;

        void Start()
        {
            level = 0;
        }

        void Awake()
        {
            Text[] texts = GetComponentsInChildren<Text>();
            textLevel = texts[0];
            textDiscription = texts[2];
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.transform;
        
        }

        void LateUpdate()
        {
            textLevel.text = $"Lv.{level+1}";
            if (level >= data.itemDescription.Length) {
                textDiscription.text = "최대 레벨입니다.";
                return;
            }
            else textDiscription.text = data.itemDescription[level];
        }

        public void OnClick()
        {
            if (level == 0) {
                weapon = Instantiate(weapon, player.position, Quaternion.identity, player);
                level++;
            }
            else if (level < data.damages.Length) {
                switch (data.itemType) {
                    case WeaponData.ItemType.Range:
                        WeaponSpawner vomitSpawner = weapon.GetComponent<WeaponSpawner>();
                        vomitSpawner.spawnInterval = data.intervals[level];
                        vomitSpawner.count = data.counts[level];
                        vomitSpawner.level = level;
                        break;

                    case WeaponData.ItemType.Axe:
                        messageSpawner mesSpawner = weapon.GetComponent<messageSpawner>();
                        mesSpawner.messagePrefab.GetComponent<message>().damage = data.damages[level];
                        mesSpawner.throwInterval = data.intervals[level];
                        mesSpawner.count = data.counts[level];
                        break;

                    case WeaponData.ItemType.Rope:
                        jumprope rope = weapon.GetComponent<jumprope>();
                        rope.damagePerTick = data.damages[level];
                        rope.tickInterval = data.intervals[level];
                        break;
                }
                level++;
            }
               
            if (level == data.damages.Length) {
                GetComponent<Button>().interactable = false;
            }


        }
    }

}
