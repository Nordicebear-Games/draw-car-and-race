[System.Serializable]
public class GameData
{
    public int currentLvl;

    public GameData(GameControl gameData)
    {
        currentLvl = gameData.currentLvl;
    }
}
