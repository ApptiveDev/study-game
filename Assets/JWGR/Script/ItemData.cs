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
        public string[] itemDescs = null;

        [Header("# Level Info")]
        public int weaponLevel = 0;
        public float damage = 0f;
        public int count = 0;
        public float speed = 0f;
        public float[] damages = null;
        public int[] counts = null;
        public float[] speeds = null;

        [Header("# Parent Object")]
        public GameObject parent = null;
    }
}