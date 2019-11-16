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

    public bool lastLvlControl = false;

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
        currentLevelText.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
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
            lastLvlControl = false;
            levelCompletedText.GetComponent<Text>().text = SceneManager.GetActiveScene().name + " Completed";
            levelCompletedText.SetActive(true);
            restartButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            lastLvlControl = true;
            levelCompletedText.GetComponent<Text>().text ="Game completed for now. Thank you for playing.";
            levelCompletedText.SetActive(true);
            restartButton.SetActive(false);
            levelsButton.SetActive(true);
        }

        GameControl.gameManager.reachedToNextLvl(SceneManager.GetActiveScene().buildIndex, stopWatch.timeStart);
        stopWatch.stopWatchState("stop");
    }
}
