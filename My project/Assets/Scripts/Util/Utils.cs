using UnityEngine;
using System.IO;
using System.Collections;
using Unity.VisualScripting;

public class Utils: MonoBehaviour
{
    private GameData gameData;

    private string path = "";
    private string persistentPath = "";

    void Start()
    {
        CreateData(false);
        SetPaths();
    }

    private void CreateData(bool firstStart)
    {
        gameData = new GameData(firstStart);
    }

    

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    
    public void SaveData()
    {
        string savePath = path;

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(gameData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);

    }

    public GameData LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        GameData data = JsonUtility.FromJson<GameData>(json);
        Debug.Log(data.ToString());

        return data;
    }
}
