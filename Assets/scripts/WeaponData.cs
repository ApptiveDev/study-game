using UnityEngine;
namespace AJH{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public enum ItemType {Axe, Range, Rope}
        [Header("Main Info")]
        public ItemType itemType;
        public int itemId;
        public string itemName;
        public string itemDescription;
        public Sprite itemIcon;
        
        
        [Header("Level data")]
        public float baseDamage;
        public int baseCount;
        public float baseSpeed;
        public float[] damages;
        public int[] counts;
        public float[] speeds;


        [Header("Weapon")]
        public GameObject projectile;
    }

}
