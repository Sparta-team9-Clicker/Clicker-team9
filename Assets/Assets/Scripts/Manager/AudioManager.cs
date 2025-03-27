using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public enum Bgms
    {
        Title,
        Main
    }

    public enum Sfxs
    {
        Button,
        Attack
    }

    [SerializeField] private AudioClip[] bgms;
    [SerializeField] private AudioClip[] sfxs;

    [SerializeField] private AudioSource audioBgm;
    [SerializeField] private AudioSource audioSfx;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PlayBgm(Bgms.Title);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBgm(Bgms bgm)
    {
        audioBgm.clip = bgms[(int)bgm];
        audioBgm.Play();
    }

    public void StopBgm()
    {
        audioBgm.Stop();
    }

    public void PlaySfx(Sfxs sfx)
    {
        audioSfx.PlayOneShot(sfxs[(int)sfx]);
    }
}
