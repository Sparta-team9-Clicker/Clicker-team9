using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject settingPanel;

    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        settingPanel.SetActive(false);

        bgmSlider.value = PlayerPrefs.GetFloat("BGM_Volume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFX_Volume", 0.5f);

        AudioManager.instance.SetBgm(bgmSlider.value);
        AudioManager.instance.SetSfx(sfxSlider.value);

        bgmSlider.onValueChanged.AddListener(SetBgm);
        sfxSlider.onValueChanged.AddListener(SetSfx);
    }

    public void SetBgm(float volume)
    {
        AudioManager.instance.SetBgm(volume);
        PlayerPrefs.SetFloat("BGM_Volume", volume);
    }

    public void SetSfx(float volume)
    {
        AudioManager.instance.SetSfx(volume);
        PlayerPrefs.SetFloat("SFX_Volume", volume);
    }

    public void OnClickSetting()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        settingPanel.SetActive(true);
    }

    public void OnClickCloseSetting()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        settingPanel.SetActive(false);
    }

    public void OnClickStartScene()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        SceneLoad.instance.ChangeScene("StartScene");
    }
}
