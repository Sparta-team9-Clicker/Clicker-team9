using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class EndingScene : MonoBehaviour
{
    public VideoPlayer video;

    void Start()
    {
        StartCoroutine(VideoPlay());
    }

    IEnumerator VideoPlay() // 화면전환 효과 끝나고 비디오 실행
    {
        yield return new WaitForSeconds(1f);
        video.Play();
    }
}
