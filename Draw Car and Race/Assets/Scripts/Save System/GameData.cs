using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int currentLvl;
    public List<float> timeList = new List<float>();

    public GameData(GameControl gameData)
    {
        currentLvl = gameData.currentLvl;
        timeList = gameData.timeList;
    }
}
