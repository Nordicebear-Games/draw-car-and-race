using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    #region Game Data
    public static void saveGameData(GameControl gameControl)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "game.fun");
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(gameControl);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData loadGameData()
    {
        string path = Path.Combine(Application.persistentDataPath, "game.fun");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData gameData = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gameData;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    #endregion

    public static void deleteDatas()
    {
        File.Delete(Application.persistentDataPath + "/game.fun");
    }
}
