using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    public Text timeText;
    public float timeStart = 0.00f;

    private bool timerActive = false;

    private void Start()
    {
        timeText.text = timeStart.ToString("F2");
    }

    private void Update()
    {
        if (timerActive)
        {
            timeStart += Time.deltaTime;
            timeText.text = timeStart.ToString("F2");
        }
    }

    public void StopWatchState(string state)
    {
        if (state == "reset")
        {
            timerActive = false;
            timeStart = 0.00f;
        }
        else if (state == "start")
        {
            timerActive = true;
            timeText.gameObject.SetActive(true);
        }
        else if (state == "stop")
        {
            timerActive = false;
        }
        else if (state == "increase")
        {
            timeStart += 1f;
        }
    }
}
