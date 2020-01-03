using UnityEngine.UI;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject lvlButtons;

    private void Start()
    {
        LvlUnlocked();
    }

    public void ChoosenLevel(string lvlName)
    {
        TransitionControl.transitionManager.LoadScene(lvlName);
    }

    private void LvlUnlocked()
    {
        GameData gameData = SaveSystem.LoadGameData();
        if (gameData != null)
        {
            //Debug.Log(gameData.currentLvl);
            for (int i = 0; i < GameControl.gameManager.numberOfLevel; i++)
            {
                if (gameData.currentLvl > i)
                {
                    Text bestTimeText = lvlButtons.transform.GetChild(i).GetChild(1).GetComponent<Text>();
                    bestTimeText.text = "Best Time: " + GameControl.gameManager.timeList[i].ToString("F2");
                    //unlock level
                    lvlButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                    lvlButtons.transform.GetChild(i).GetChild(0).gameObject.SetActive(true); //level text
                    lvlButtons.transform.GetChild(i).GetChild(1).gameObject.SetActive(true); //best time text
                    lvlButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false); //lock image
                }
            }
        }
    }
}
