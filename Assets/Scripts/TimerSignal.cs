using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TimerSignal : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    private void Awake()
    {
        _timerText = GetComponent<Text>();
    }

    public void StartTimer(float duration)
    {
        gameObject.SetActive(true);
        StartTimerTask(duration);
    }

    private async void StartTimerTask(float duration)
    {
        await UpdateTimer(duration);
    }

    private async Task UpdateTimer(float duration)
    {
        float durationTimer = duration;
        while (durationTimer > 0)
        {
            _timerText.text = durationTimer.ToString();
            await Task.Delay(TimeSpan.FromSeconds(1));
            durationTimer --;
            Debug.Log($"Starting in {durationTimer} seconds...");
        }
        _timerText.text = "Start!";
        await Task.Delay(TimeSpan.FromSeconds(1));
        gameObject.SetActive(false);
    }
}
