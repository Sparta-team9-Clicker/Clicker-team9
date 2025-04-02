using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject settingPanel; // 설정 판넬
    
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

    public void OnClickSetting() // 세팅 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        settingPanel.SetActive(true);
    }

    public void OnClickCloseSetting() // 세팅창 닫기 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        settingPanel.SetActive(false);
    }    

    public void OnClickStartScene() // 메인씬에서 스타트씬으로 가기 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        AudioManager.instance.PlayBgm(AudioManager.Bgms.Title);
        SceneLoad.instance.ChangeScene("StartScene");
    }    

    public void OnClickExitBtn() // 나가기 버튼
    {
#if UNITY_EDITOR        
        GameManager.Instance.SaveData();
        UnityEditor.EditorApplication.isPlaying = false;
#else        
        GameManager.Instance.SaveData();
        Application.Quit();
#endif
    }    
}
