using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    void Awake()
    {
        instance = this;
    }

}


