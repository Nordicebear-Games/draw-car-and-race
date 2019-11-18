using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public GameObject lvlButtons;

    private void Start()
    {
        lvlUnlocked();
    }

    public void choosenLevel(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    private void lvlUnlocked()
    {
        GameData gameData = SaveSystem.loadGameData();
        if (gameData != null)
        {
            //Debug.Log(gameData.currentLvl);
            for (int i = 0; i < lvlButtons.transform.childCount; i++)
            {
                lvlButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                if (i <= gameData.currentLvl)
                {
                    try
                    {
                        lvlButtons.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "Best Time: " + gameData.timeList[i].ToString("F2");
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        lvlButtons.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "Best Time: " + 0f.ToString("F2");
                    }
                    //unlock level
                    lvlButtons.transform.GetChild(i).GetChild(0).gameObject.SetActive(true); //level text
                    lvlButtons.transform.GetChild(i).GetChild(1).gameObject.SetActive(true); //best time text
                    lvlButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false); //lock image
                }
            }
        }
    }
}
