using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int currentLvl;
    public List<float> timeList = new List<float>();
    public static GameControl gameManager { get; private set; }

    public int numberOfLevel;

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
        LoadGameData();

        LoadReachedLvl();

    }

    private void LoadReachedLvl()
    {
        if (currentLvl <= numberOfLevel)
        {
            SceneManager.LoadScene("Level " + currentLvl);
        }
        else
        {
            SceneManager.LoadScene("Level " + (currentLvl - 1));
        }
    }

    public void ReachedToNextLvl(int lvl, float newTime)
    {
        if (lvl == currentLvl)
        {
            currentLvl = lvl + 1;
        }

        if (newTime < timeList[lvl - 1] || timeList[lvl - 1] == 0f)
        {
            timeList[lvl - 1] = Mathf.Round(newTime * 100f) / 100f;
        }

        SaveGameData();
    }

    #region Save and Load System
    public void SaveGameData()
    {
        SaveSystem.SaveGameData(this);
    }

    public void LoadGameData()
    {
        GameData gameData = SaveSystem.LoadGameData();

        if (gameData != null)
        {
            currentLvl = gameData.currentLvl;

            for (int i = 0; i < numberOfLevel; i++)
            {
                timeList.Add(0f);
                if (gameData.timeList.Count > i)
                {
                    timeList[i] = gameData.timeList[i];
                }
            }
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
