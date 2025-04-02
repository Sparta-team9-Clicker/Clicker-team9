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

    IEnumerator VideoPlay() // ȭ����ȯ ȿ�� ������ ���� ����
    {
        yield return new WaitForSeconds(1f);
        video.Play();
    }
}
