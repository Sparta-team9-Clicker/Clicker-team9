using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData;

    string path;
    string filename = "saveData.json";

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
    }

    public void SaveData()
    {        
        string fullPath = path + filename;
        string data = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(fullPath, data);
        print($"������: {fullPath}");
    }

    public void LoadData(int dataIndex)
    {
        string fullPath = path + filename;

        if (File.Exists(fullPath))
        {            
            string data = File.ReadAllText(fullPath);
            playerData = JsonUtility.FromJson<PlayerData>(data);
            print($"�ε�� ����: {fullPath}");
        }
        else
        {
            print("����� ������ �����ϴ�.");
            playerData = new PlayerData(1, 10, 120, 5f, 1000, 1, 1, 1, 1, false);
        }
    }
}
