using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData;
    public PlayerStat playerStat;

    string path;
    int curdataIndex = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            path = Application.persistentDataPath + "/";
        }
        else
        {
            Destroy(this.gameObject);
        }
        LoadData(1);
    }

    public void SaveData()
    {
        string filename = $"saveData_{curdataIndex}.json";
        string fullPath = path + filename;
        string data = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(fullPath, data);
        print($"������: {fullPath}");
    }

    public void LoadData(int dataIndex)
    {
        curdataIndex = dataIndex;
        string filename = $"saveData_{dataIndex}.json";
        string fullPath = path + filename;

        if (File.Exists(fullPath))
        {            
            string data = File.ReadAllText(fullPath);
            playerData = JsonUtility.FromJson<PlayerData>(data);
            print($"�ε�� ����: {fullPath}");
        }

        if (playerData == null)
        {
            print("����� ������ �����ϴ�.");
            playerData = new PlayerData(1, 10, 120, 5f, 1000, 0, 0, 0, 0, false);
            SaveData();
        }
    }
}
