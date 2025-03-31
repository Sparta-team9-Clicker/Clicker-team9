using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public Image jelly;
    public Image jellyLogo;
    public Image tabLogo;
    public Image particle;

    public Animator jellyAnim;
    public Animator jellyLogoAnim;
    public Animator tabLogoAnim;
    public Animator particleAnim;    

    private void Start()
    {
        jelly.enabled = false;
        jellyLogo.enabled = false;
        tabLogo.enabled = false;
        particle.enabled = false;

        StartCoroutine(StartLogo());
    }

    IEnumerator StartLogo()
    {
        jelly.enabled = true;
        jellyAnim.Play("Jelly", 0, 0f);
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Bubble);
        yield return new WaitForSeconds(0.5f);

        jellyLogo.enabled = true;
        jellyLogoAnim.Play("Jellytext", 0 ,0f);
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Bubble);
        yield return new WaitForSeconds(0.5f);

        tabLogo.enabled = true;
        tabLogoAnim.Play("Tabtext", 0, 0f);
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Bubble);
        yield return new WaitForSeconds(0.5f);

        particle.enabled = true;
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Particle);
        particleAnim.Play("Particle", 0, 0f);
    }

    public void OnClickJelly()
    {
        jellyAnim.SetTrigger("Click");
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Bubble);
    }
}
