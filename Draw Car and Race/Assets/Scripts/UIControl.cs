using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject currentLevelText;
    public GameObject DrawCarAndRace;
    public GameObject levelCompletedText;
    public GameObject restartButton;
    public GameObject nextButton;
    public GameObject levelsButton;

    [Header("StopWatch")]
    public StopWatch stopWatch;
    public Text bestTimeText;

    private int lvlIndex;

    //public bool lastLvlControl = false;
    public bool drawCarControl = true;

    public static UIControl UIManager { get; private set; }

    private void Awake()
    {
        if (UIManager == null)
        {
            UIManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        drawCarControl = true;
        bestTime();
        currentLevelText.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }

    public void raceStarted()
    {
        currentLevelText.SetActive(false);
        DrawCarAndRace.SetActive(false);
        levelsButton.SetActive(false);
        restartButton.SetActive(true);
        stopWatch.stopWatchState("start");
    }

    private void bestTime()
    {
        bestTimeText.text = "Best: " + GameControl.gameManager.timeList[findLvlIndex() - 1].ToString("F2");
    }

    private int findLvlIndex() //find level index according to level name
    {
        string lvlName = SceneManager.GetActiveScene().name;
        for (int i = 1; i <= GameControl.gameManager.numberOfLevel; i++)
        {
            if (lvlName == "Level " + i.ToString())
            {
                lvlIndex = i;
            }
        }
        return lvlIndex;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        stopWatch.stopWatchState("reset");
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void lvlScreen()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void levelCompleted()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            //lastLvlControl = false;
            levelCompletedText.GetComponent<Text>().text = SceneManager.GetActiveScene().name + " Completed";
            levelCompletedText.SetActive(true);
            restartButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            //lastLvlControl = true;
            levelCompletedText.GetComponent<Text>().text ="Game completed for now. Thank you for playing.";
            levelCompletedText.SetActive(true);
            restartButton.SetActive(false);
            levelsButton.SetActive(true);
        }

        drawCarControl = false;
        GameControl.gameManager.reachedToNextLvl(findLvlIndex(), stopWatch.timeStart);
        bestTime();
        stopWatch.stopWatchState("stop");
    }
}
