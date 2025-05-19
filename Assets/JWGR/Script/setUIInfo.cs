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
            if (ItemDesc.text != null) ItemDesc.text = desc;
            if (ItemName.text != null) ItemName.text = name;
            if (ItemState.text != null) ItemState.text = state;
            if (ItemImg.sprite != null) ItemImg.sprite = icon;
        }
    }
}