using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public static SceneLoad instance;
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;   
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (fadeImage != null)
            fadeImage.gameObject.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(TransitionScene(sceneName));
    }

    private IEnumerator TransitionScene(string sceneName)
    {
        fadeImage.gameObject.SetActive (true);
        yield return Fade(1f);

        SceneManager.LoadScene(sceneName);

        yield return new WaitForSeconds(0.5f);

        yield return Fade(0f);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float elapsedTime = 0f;

        while(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r,fadeImage.color.g,fadeImage.color.b,alpha);
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, targetAlpha);
    }
}
