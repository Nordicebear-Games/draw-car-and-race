using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int currentLvl;
    public static GameControl gameManager { get; private set; }

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //SaveSystem.deleteDatas();
        loadGameData();
        SceneManager.LoadScene("Level " + currentLvl);
    }

    public void reachedToNextLvl(int lvl)
    {
        if (lvl > currentLvl)
        {
            currentLvl = lvl;
            Debug.Log(currentLvl);
        }
        saveGameData();
    }

    #region Save and Load System
    public void saveGameData()
    {
        SaveSystem.saveGameData(this);
    }

    public void loadGameData()
    {
        GameData gameData = SaveSystem.loadGameData();

        if (gameData != null)
        {
            currentLvl = gameData.currentLvl;
        }
        else
        {
            currentLvl = 1;
        }
    }
    #endregion
}
