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

    public void choosenLevel(int lvlIndex)
    {
        lvlIndex++;
        SceneManager.LoadScene("Level " + lvlIndex.ToString());
    }

    private void lvlUnlocked()
    {
        GameData gameData = SaveSystem.loadGameData();
        if (gameData != null)
        {
            //Debug.Log(gameData.currentLvl);
            for (int i = 0; i < gameData.currentLvl; i++)
            {
                lvlButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                lvlButtons.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "Best Time: " + gameData.timeList[i].ToString("F2");
                lvlButtons.transform.GetChild(i).GetChild(0).gameObject.SetActive(true); //level text
                lvlButtons.transform.GetChild(i).GetChild(1).gameObject.SetActive(true); //best time text
                lvlButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false); //lock image
            }
        }
    }
}
