using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionControl : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject transitionPanel;


    public static TransitionControl transitionManager { get; private set; }

    private void Awake()
    {
        if (transitionManager == null)
        {
            transitionManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void loadScene(string sceneName)
    {
        StartCoroutine(transitionBetweenScenes(sceneName));
    }

    private IEnumerator transitionBetweenScenes(string sceneName)
    {
        transitionAnim.SetTrigger("transition");
        yield return new WaitUntil(() => transitionPanel.transform.localScale.x == 2);
        SceneManager.LoadScene(sceneName);
    }
}
