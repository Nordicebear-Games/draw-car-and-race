using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
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

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void levelCompleted()
    {
        levelCompletedText.SetActive(true);
        restartButton.SetActive(false);
        nextButton.SetActive(true);
    }
}
