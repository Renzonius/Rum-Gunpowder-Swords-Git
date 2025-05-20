using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[Header("PLAYER STATE")]
    //[Header("BOSS STATE")]

    [Header("GAME SETTINGS")]
    [SerializeField] private float _timerDuration = 3f;
    [SerializeField] private int _numberOfWave = 0;
    [SerializeField] private int _maxNumberOfWave = 3;

    //[Header("CONTROLLERS")]
    //[SerializeField] private BridgeController _bridgeController;

    public float TimerDuration { get => _timerDuration; }
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        WaveController.Instance.OnWaveEnded += HandleWaveEnded;
    }

    private void OnDisable()
    {
        WaveController.Instance.OnWaveEnded -= HandleWaveEnded;
    }

    //Este metodo utiliza "WaveControllers" para iniciar las siguientes oleadas.
    private async void HandleWaveEnded(int waveNumber) 
    {
        waveNumber++;
        await Task.Delay(3000);                                  //Esperamos 3 seg. antes de iniciar el timer y la nueva oleada.
        UIManager.Instance.ActivateTimerSignal();
        WaveController.Instance.initializedWaveAsync(waveNumber);
    }

    public void StartGame()
    {
        WaveController.Instance.initializedWaveAsync(_numberOfWave);
    }
}
