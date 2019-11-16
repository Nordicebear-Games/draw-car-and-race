using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int currentLvl;
    public List<float> timeList = new List<float>();
    public static GameControl gameManager { get; private set; }

    private int numberOfLevel = 5;

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

    public void reachedToNextLvl(int lvl, float newTime)
    {
        if (lvl > currentLvl && !UIControl.UIManager.lastLvlControl)
        {
            currentLvl = lvl;
        }

        if (newTime < timeList[lvl - 2] || timeList[lvl - 2] == 0f)
        {
            timeList[lvl - 2] = Mathf.Round(newTime * 100f) / 100f;
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
            timeList = gameData.timeList;
        }
        else
        {
            currentLvl = 1;

            for (int i = 0; i < numberOfLevel; i++)
            {
                timeList.Add(0f);
            }
        }
    }
    #endregion
}
