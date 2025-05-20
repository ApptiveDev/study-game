using UnityEngine;

namespace JWGR
{
    public class ItemData : MonoBehaviour
    {
        public enum ItemType { Melee, Range, Heal }

        [Header("# Main Info")]
        public ItemType itemType;
        public int itemId = 0;
        public string itemName = "";
        public string itemDesc = "";
        public string itemState = "new!";
        public Sprite itemIcon = null;
        public bool canSpawn = false;
        public string[] itemDescs = new string[0];

        [Header("# Level Info")]
        public int weaponLevel = 0;
        public float damage = 0f;
        public int count = 0;
        public float speed = 0f;
        public float[] damages = new float[0];
        public int[] counts = new int[0];
        public float[] speeds = new float[0];

        void Awake ()
        {
            weaponLevel = 0;
        }
    }
}