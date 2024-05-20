using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Slider slider;
    //BODController player;

    public void ChangeHpBar(int i)
    {
        slider.value = i;
    }

    //void Follow()
    //{
    //    transform.position = new Vector3(975, 400, 0) + player.transform.position * 67.5f;
    //}

    void InitHpBar()
    {
        slider.maxValue = GameDataController.Instance.GetHp();
        slider.value = slider.maxValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        //player = GameManager.Instance.getPlayer().GetComponent<BODController>();
        InitHpBar();
    }
}