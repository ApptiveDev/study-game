using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace JWGR
{
    public class setUIInfo : MonoBehaviour
    {
        [SerializeField] Text ItemDesc;
        [SerializeField] Text ItemName;
        [SerializeField] Text ItemState;
        [SerializeField] Image ItemImg;

        public void SetInfo(string desc, string name, string state, Sprite icon)
        {
            ItemDesc.text = desc;
            ItemName.text = name;
            ItemState.text = state;
            ItemImg.sprite = icon;
        }
    }
}