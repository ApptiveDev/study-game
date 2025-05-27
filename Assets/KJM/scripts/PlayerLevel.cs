using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace KJM
{
    public class PlayerLevel : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(CheckExp());
        }
        
        private IEnumerator CheckExp()
        {
            while (true)
            {
                if (Player.Instance.exp >= Player.Instance.max_exp)
                {
                    Player.Instance.level++;
                    Player.Instance.exp = 0;
                    Inventory.Instance.RandomWeaponSelect();
                    //StartCoroutine(Levelup());
                }
                yield return null;
            }
        }
    }
}