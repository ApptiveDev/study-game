using AJH;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public enum InfoType { Exp, Level, kill, Time, Health }
    public InfoType type;

    TextMeshProUGUI myText;
    Slider mySlider;
    
    void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        mySlider = GetComponent<Slider>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        float curExp = GameManager.instance.exp;
        float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
        switch (type) {
            case InfoType.Exp:
                if (mySlider != null) {
                    mySlider.value = curExp / maxExp;
                }
                break;

            case InfoType.Level:
                int curLevel = GameManager.instance.level;
                if (myText != null)
                {
                    myText.text = $"Level {curLevel} - {curExp}/{maxExp}";
                }
                break;

            case InfoType.kill:
                break;
            case InfoType.Time:
                break;
            case InfoType.Health:
                float curWeight = GameManager.instance.weight;
                if (mySlider != null)
                {
                    float maxWeight = GameManager.instance.maxWeight;
                    mySlider.value = (curWeight-45) / (maxWeight-45);
                }

                if (myText != null)
                {
                    curWeight = GameManager.instance.weight;
                    myText.text = $"{curWeight:0.0}kg";
                }
                break;
        }
    }
}
