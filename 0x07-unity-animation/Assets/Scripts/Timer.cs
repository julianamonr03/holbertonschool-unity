using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float startTime;

    void Start() {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        TimerText.text = minutes + ":" + seconds;
    }
}

