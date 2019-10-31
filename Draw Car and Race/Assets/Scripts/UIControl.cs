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
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void levelCompleted()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            levelCompletedText.GetComponent<Text>().text = SceneManager.GetActiveScene().name + " Completed";
            levelCompletedText.SetActive(true);
            restartButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            levelCompletedText.GetComponent<Text>().text ="Game Completed. Thank you for playing.";
            levelCompletedText.SetActive(true);
            restartButton.SetActive(false);
        }
    }
}
