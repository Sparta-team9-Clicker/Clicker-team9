using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataLoad : MonoBehaviour
{
    public GameObject savePanel;
    
    void Start()
    {
        savePanel.SetActive(false);
    }

    public void OnClickCloseSave()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        savePanel.SetActive(false);
    }

    public void OnClickStartBtn()
    {
        savePanel.SetActive(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);        
    }

    public void LoadData1()
    {
        GameManager.Instance.LoadData(1);
        SceneLoad.instance.ChangeScene("MainScene");
    }

    public void LoadData2()
    {
        GameManager.Instance.LoadData(2);
        SceneLoad.instance.ChangeScene("MainScene");
    }

    public void LoadData3()
    {
        GameManager.Instance.LoadData(3);
        SceneLoad.instance.ChangeScene("MainScene");
    }
}
