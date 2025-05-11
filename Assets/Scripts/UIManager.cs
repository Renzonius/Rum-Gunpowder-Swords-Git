using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private TimerSignal _timerSignal;
    [SerializeField] private float _timerDuration = 3f;

    public void ActivateTimerSignal()
    {
        _timerSignal.StartTimer(_timerDuration);
    }

    public void LoadScene(string sceneName)
    {
        _sceneController.LoadScene(sceneName);
    }
}
