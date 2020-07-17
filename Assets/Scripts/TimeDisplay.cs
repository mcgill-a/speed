using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [Tooltip("Best Lap")]
    public TimeDisplayItem bestLapText;
    public TimeDisplayItem currentLapText;

    private float currentLapStartTime;
    private List<float> lapTimes = new List<float>();
    private bool lapStarted = false;
    private bool lapFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        bestLapText.SetText("");
        bestLapText.SetTitle("Best Lap:");

        currentLapText.SetText("");
        currentLapText.SetTitle("Current Lap:");
    }

    float GetBestLapTime()
    {
        if (lapTimes.Count == 0)
        {
            return 0f;
        }

        float best = float.MaxValue;
        for (int i = 0; i < lapTimes.Count; i++)
        {
            if (lapTimes[i] < best)
            {
                best = lapTimes[i];
            }
        }

        return best;
    }

    string GetBestLapTimeStr()
    {
        return GetTimeString(GetBestLapTime());
    }

    float GetCurrentLapTime()
    {
        return Time.time - currentLapStartTime;
    }

    string GetLapTimeStr()
    {
        float currentLapTime = GetCurrentLapTime();
        if (currentLapTime < 0.01f) return "0:00";
        return GetTimeString(currentLapTime);
    }

    string GetTimeString(float time)
    {
        int timeInt = (int)(time);
        int minutes = timeInt / 60;
        int seconds = timeInt % 60;
        float fraction = (time * 100) % 100;
        if (fraction > 99) fraction = 99;
        return string.Format("{0}:{1:00}:{2:00}", minutes, seconds, fraction);
    }

    public void StartTimer()
    {
        lapFinished = false;
        lapStarted = true;
        currentLapStartTime = Time.time;
    }

    public void StopTimer()
    {
        if (lapStarted) // && allCheckpointsTriggered
        {
            // Stop the lap timer
            lapFinished = true;
            // Add the lap to laps array
            lapTimes.Add(GetCurrentLapTime());
            // Update the best lap
            bestLapText.SetText(GetBestLapTimeStr());
            lapStarted = false;
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        lapStarted = false;
        currentLapText.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (lapStarted && !lapFinished)
        {
            currentLapText.SetText(GetLapTimeStr());
        }

    }
}
