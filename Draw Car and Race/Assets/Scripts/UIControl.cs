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

    public bool drawControl = true;

    private int lvlIndex;

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
        drawControl = true;
        BestTime();
        currentLevelText.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }

    public void RaceStarted()
    {
        currentLevelText.SetActive(false);
        DrawCarAndRace.SetActive(false);
        levelsButton.SetActive(false);
        restartButton.SetActive(true);
        stopWatch.StopWatchState("start");
    }

    private void BestTime()
    {
        bestTimeText.text = "Best: " + GameControl.gameManager.timeList[FindLvlIndex() - 1].ToString("F2");
    }

    private int FindLvlIndex() //find level index according to level name
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

    public void RestartGame()
    {
        TransitionControl.transitionManager.LoadScene(SceneManager.GetActiveScene().name);
        stopWatch.StopWatchState("reset");
    }

    public void NextLevel()
    {
        TransitionControl.transitionManager.LoadScene("Level " + (FindLvlIndex() + 1).ToString());
    }

    public void LvlScreen()
    {
        //SceneManager.LoadScene("LevelScreen");
        TransitionControl.transitionManager.LoadScene("LevelScreen");
    }

    public void LevelCompleted()
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

        drawControl = false;
        GameControl.gameManager.ReachedToNextLvl(FindLvlIndex(), stopWatch.timeStart);
        BestTime();
        stopWatch.StopWatchState("stop");
    }
}
