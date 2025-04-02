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

    public void ChangeScene(string sceneName) // 씬 전환시 페이드이미지 코루틴 실행
    {
        StartCoroutine(TransitionScene(sceneName));
    }

    private IEnumerator TransitionScene(string sceneName) // 이미지 켜졌다가 꺼지는 코루틴
    {
        fadeImage.gameObject.SetActive (true);
        yield return Fade(1f);

        SceneManager.LoadScene(sceneName);

        yield return new WaitForSeconds(0.5f);

        yield return Fade(0f);
        fadeImage.gameObject.SetActive(false);
    }

    private IEnumerator Fade(float targetAlpha) // 이미지 알파값이 증가했다가 떨어지는 코루틴
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

    public IEnumerator TransitionStage() // 스테이지 전환 시 코루틴
    {        
        fadeImage.gameObject.SetActive(true);
        yield return Fade(1f);

        yield return new WaitForSeconds(0.5f);

        yield return Fade(0f);
        fadeImage.gameObject.SetActive(false);
        StageManager.Instance.NextStage();
    }
}
