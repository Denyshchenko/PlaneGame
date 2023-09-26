using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    
    public static void SaveData(DataLoader dataLoader)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dataLoader.GameData";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(dataLoader);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/dataLoader.GameData";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data; 
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
