using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData;

    //string path;
    //string filenamePrefix = "save_";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            //path = Application.persistentDataPath + "/";
            playerData = new PlayerData(1, 10, 120, 5, 1000, 1, 1, 1, 1, false);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //public void SaveData()
    //{
    //    string fullPath = path + filenamePrefix + playerData.GetHashCode() + ".json";
    //    string data = JsonUtility.ToJson(playerData);
    //    File.WriteAllText(fullPath, data);
    //    print($"저장경로: {fullPath}");
    //}
}
