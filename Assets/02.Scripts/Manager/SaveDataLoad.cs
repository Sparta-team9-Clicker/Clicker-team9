using System.IO;
using TMPro;
using UnityEngine;

public class SaveDataLoad : MonoBehaviour
{
    public GameObject savePanel;

    public TextMeshProUGUI save1Text;
    public TextMeshProUGUI save2Text;
    public TextMeshProUGUI save3Text;

    private string path;
    
    void Start()
    {
        path = Application.persistentDataPath + "/";
        savePanel.SetActive(false);        
        UpdateSaveSlots();
    }

    public void UpdateSaveSlots()
    {
        LoadSaveSlot(1, save1Text);
        LoadSaveSlot(2, save2Text);
        LoadSaveSlot(3, save3Text);
    }

    public void LoadSaveSlot(int slotIndex, TextMeshProUGUI saveText) // 슬롯 3개 중 로드할 데이터 선택
    {
        string filename = $"saveData_{slotIndex}.json";
        string fullPath = path + filename;

        if (File.Exists(fullPath))
        {
            string data = File.ReadAllText(fullPath);
            PlayerData tempData = JsonUtility.FromJson<PlayerData>(data);
            saveText.text = $"Data\nGold : {tempData.gold:N0}\nPower : {tempData.attackPower:N0}";
        }
        else
        {
            saveText.text = "Data Empty";
        }
    }

    public void OnClickCloseSave() // 세이브 창 닫기
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        savePanel.SetActive(false);
    }

    public void OnClickStartBtn() // 시작버튼
    {
        savePanel.SetActive(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        UpdateSaveSlots();
    }

    public void LoadData1() // 데이터 1번 로드
    {
        GameManager.Instance.LoadData(1);
        SceneLoad.instance.ChangeScene("MainScene");
        AudioManager.instance.PlayBgm(AudioManager.Bgms.Stage1);
    }

    public void LoadData2() // 데이터 2번 로드
    {
        GameManager.Instance.LoadData(2);
        SceneLoad.instance.ChangeScene("MainScene");
        AudioManager.instance.PlayBgm(AudioManager.Bgms.Stage1);
    }

    public void LoadData3() // 데이터 3번 로드
    {
        GameManager.Instance.LoadData(3);
        SceneLoad.instance.ChangeScene("MainScene");
        AudioManager.instance.PlayBgm(AudioManager.Bgms.Stage1);
    }
}
