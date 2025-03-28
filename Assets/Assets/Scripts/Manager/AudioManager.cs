using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public enum Bgms
    {
        Title,
        Stage1,
        Stage2,
        Stage3
    }

    public enum Sfxs
    {
        Button,
        Attack
    }

    [System.Serializable]
    public class BgmClip
    {
        public Bgms type;
        public AudioClip clip;
    }

    [System.Serializable]
    public class SfxClip
    {
        public Sfxs type;
        public AudioClip clip;
    }

    [SerializeField] private List<BgmClip> bgmClips;
    [SerializeField] private List<SfxClip> sfxClips;


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
        foreach(var bgmClip in bgmClips)
        {
            if(bgmClip.type == bgm)
            {
                audioBgm.clip = bgmClip.clip;
                audioBgm.Play();
                return;
            }
        }
    }

    public void StopBgm()
    {
        audioBgm.Stop();
    }

    public void PlaySfx(Sfxs sfx)
    {
        foreach(var sfxClip in sfxClips)
        {
            if(sfxClip.type == sfx)
            {                
                audioSfx.PlayOneShot(sfxClip.clip);
                return;
            }
        }
    }

    public void SetBgm(float volume)
    {
        audioBgm.volume = volume;
    }

    public void SetSfx(float volume)
    {
        audioSfx.volume = volume;
    }
}
