using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public Image zelly;
    public Image zellyLogo;
    public Image tabLogo;
    public Image particle;

    public Animator zellyAnim;
    public Animator zellyLogoAnim;
    public Animator tabLogoAnim;
    public Animator particleAnim;

    private void Start()
    {
        zelly.enabled = false;
        zellyLogo.enabled = false;
        tabLogo.enabled = false;
        particle.enabled = false;

        StartCoroutine(StartLogo());
    }

    IEnumerator StartLogo()
    {
        zelly.enabled = true;
        zellyAnim.Play("Zelly", 0, 0f);
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Bubble);
        yield return new WaitForSeconds(0.5f);

        zellyLogo.enabled = true;
        zellyLogoAnim.Play("Zellytext", 0 ,0f);
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
}
