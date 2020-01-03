using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadScene(string sceneName)
    {
        StartCoroutine(TransitionBetweenScenes(sceneName));
    }

    private IEnumerator TransitionBetweenScenes(string sceneName)
    {
        transitionAnim.SetTrigger("transition");
        yield return new WaitUntil(() => transitionPanel.transform.localScale.x == 2);
        SceneManager.LoadScene(sceneName);
    }
}
