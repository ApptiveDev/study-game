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
        public string[] itemDescription;
        public Sprite itemIcon;
        
        
        [Header("Level data")]
        public float baseDamage;
        public int baseCount;
        public float baseInterval;
        public float[] damages;
        public int[] counts;
        public float[] intervals;


        [Header("Weapon")]
        public GameObject projectile;
    }

}
