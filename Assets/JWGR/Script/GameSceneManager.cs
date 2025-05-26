using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JWGR
{
    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField] Button titleButton;

        private void Start()
        {
            titleButton.onClick.AddListener(OnClickTitle);
        }

        private void OnClickTitle()
        {
            SceneManager.LoadScene("Title");
        }
    }
}
