using System.Collections;
using UnityEngine;

public class titlePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer characterSprite;
    public Transform character;
    public CanvasGroup fadePanel;
    public float moveDuration = 3f;
    public float fadeDuration = 1.2f;
    public Animator animator;

    // private void Start()
    // {
    //     characterSprite = GetComponentInChildren<SpriteRenderer>();
    //     animator = GetComponent<Animator>();
    // }
    public void OnStartButtonClicked()
    {
        StartCoroutine(playerMove(false));
    }

    public void OnShopButtonClicked()
    {
        StartCoroutine(playerMove(true));
    }


    private IEnumerator playerMove(bool isLeft)
    {
        // Move the character to the right
        animator.SetFloat("speed", 3f); // Set the animation speed to 1 to play the walking animation
        Vector3 startPosition = character.position;
        Vector3 endPosition;
        if (isLeft) endPosition = startPosition + new Vector3(-5f, 0f, 0f);
        else
        {
            characterSprite.flipX = true; // Ensure the character is facing right
            endPosition = startPosition + new Vector3(5f, 0f, 0f);
        }
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            character.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        character.position = endPosition;

        // Fade out the panel
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadePanel.alpha = 1f;

        yield return new WaitForSeconds(0.5f);

        if (!isLeft) yield return StartCoroutine(LoadSceneAsync("week1_hw"));
        else yield return StartCoroutine(LoadSceneAsync("shop"));
    }
    // Update is called once per frame
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // Prevent the scene from activating immediately
        while (asyncLoad.progress < 0.9f) // Wait until the scene is loaded
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.1f); // Optional delay before activating the scene
        asyncLoad.allowSceneActivation = true; // Activate the scene
    }
}
