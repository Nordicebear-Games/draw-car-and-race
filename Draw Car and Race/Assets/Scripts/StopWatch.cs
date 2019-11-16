using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    public Text textBox;

    public float timeStart = 0.00f;
    private bool timerActive = false;

    private void Start()
    {
        textBox.text = timeStart.ToString("F2");
    }

    private void Update()
    {
        if (timerActive)
        {
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
        }
    }

    public void stopWatchState(string state)
    {
        if (state == "reset")
        {
            timerActive = false;
            timeStart = 0.00f;
        }
        else if (state == "start")
        {
            timerActive = true;
            textBox.gameObject.SetActive(true);
        }
        else if (state == "stop")
        {
            timerActive = false;
        }
    }
}
