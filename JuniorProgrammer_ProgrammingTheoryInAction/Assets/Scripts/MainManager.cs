using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    [SerializeField] private PlayerData data;
    private string username;
    private string pathFile;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        pathFile = Application.persistentDataPath + "/PlayerData.json";
        LoadData();
    }
    public void LoadData()
    {
        if (File.Exists(pathFile))
        {
            string jsonText = File.ReadAllText(pathFile);
            data = new PlayerData(JsonUtility.FromJson<PlayerData>(jsonText));
            username = data.GetUsername();
        }
        else
        {
            username = "";
            data = new PlayerData();
        }
    }
    public void SaveData()
    {
        if (username != "")
        {
            string jsonText = JsonUtility.ToJson(data);
            File.WriteAllText(pathFile, jsonText);
        }
    }
    public bool CanStartGame(string username)
    {
        this.username = username;
        if (this.username != "")
        {
            if (!this.username.Equals(data.GetUsername()))
                data = new PlayerData(username);
            return true;
        }
        else
            return false;
    }
    public string GetUsername() { return username; }
}
