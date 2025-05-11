using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[Header("PLAYER STATE")]
    //[Header("BOSS STATE")]

    [Header("GAME SETTINGS")]
    [SerializeField] private float _timerDuration = 3f;

    [Header("CONTROLLERS")]
    [SerializeField] private BridgeController _bridgeController;


    public float TimerDuration { get => _timerDuration; }
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
