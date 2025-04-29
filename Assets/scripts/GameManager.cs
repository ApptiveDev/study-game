using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public player player;

    void Awake()
    {
        instance = this;
    }

}


