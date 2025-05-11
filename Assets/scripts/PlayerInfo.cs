using AJH;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public enum InfoType { Exp, Level, kill, Time, Health }
    public InfoType type;

    Text myText;
    Slider mySlider;
    
    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        switch (type) {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.level];

                break;
            case InfoType.Level:
                break;
            case InfoType.kill:
                break;
            case InfoType.Time:
                break;
            case InfoType.Health:
                break;
        }
    }
}
