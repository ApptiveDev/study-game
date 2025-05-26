using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JWGR
{
    public class TitleSceneManager : MonoBehaviour
    {
        [SerializeField] Button gameButton;
        [SerializeField] Button storeButton;

        private void Start()
        {
            gameButton.onClick.AddListener(OnClickGame);
            storeButton.onClick.AddListener(OnClickStore);
        }

        private void OnClickGame()
        {
            SceneManager.LoadScene("Game");
        }

        private void OnClickStore()
        {
            SceneManager.LoadScene("Store");
        }
    }
}