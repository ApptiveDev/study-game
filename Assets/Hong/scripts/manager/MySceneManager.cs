using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace AJH
{
    public class MySceneManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void LoadGameScene()
        {
            SceneManager.LoadScene("week1_hw");
        }

    }
    
}
