using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("CONTROLLERS")]
    [SerializeField] private SceneController _sceneController;

    [Header("TIMER SIGNAL SETTINGS")]
    [SerializeField] private TimerSignal _timerSignal;
    [SerializeField] private float _timerDuration;

    [Header("MENUS")]
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;

    private void Start()
    {
        _timerDuration = GameManager.Instance.TimerDuration;
    }

    public void ActivateTimerSignal()
    {
        _timerSignal.StartTimer(_timerDuration);
    }

    public void LoadScene(string sceneName)
    {
        _sceneController.LoadScene(sceneName);
    }
}
