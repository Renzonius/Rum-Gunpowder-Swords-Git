using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


public class WaveController : MonoBehaviour
{
    [SerializeField] private Wave[] scriptableWaves;
    [SerializeField] private int _numberOfWave = 0; 
    [SerializeField] private int numberOfEnemies;

    [Header("CONTROLLERS")]
    [SerializeField] private BridgeController _bridgeController;
    [SerializeField] private EnemySpawn _enemySpawn;

    public event Action<int> OnWaveEnded;

    public static WaveController Instance { get; private set; }

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

    public async void initializedWaveAsync(int numberOfWave)
    {
        _numberOfWave = numberOfWave;
        await SetWave(numberOfWave);                        
    }

    public async void EndWaveAsync(int numberOfWave)
    {
        _bridgeController.CollapseBridge(1f, numberOfWave); //Colapsamos el puente en la oleada correspondiente.
        await Task.Delay(1000);                             //Esperamos 1 segundos para que el puente se colapse.
        if(numberOfWave < scriptableWaves.Length - 1) 
        {
            OnWaveEnded?.Invoke(numberOfWave);              //Invocamos el evento de que la oleada ha terminado.
        }

    }

    public void subtractEnemy()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0)
        {
            EndWaveAsync(_numberOfWave);                        //Si no hay enemigos, terminamos la oleada.
        }
    }

    private async Task SetWave(int numberOfWave)
    {
        _bridgeController.ExtendBridge(3f, numberOfWave);               //Extendemos el puente en la oleada correspondiente.
        numberOfEnemies = scriptableWaves[numberOfWave].CountEnemies;   //Guardamos la cantidad de enemigos en la oleada actual.

        await Task.Delay(3000);                                         //Esperamos 3 segundos para que el puente se extienda.
        await SpawnEnemies(numberOfWave);                               //Spawneamos la cantidad total de enemigos en la oleada.
    }



    private async Task SpawnEnemies(int numberOfWave)
    {
        for (int i = 0; i < scriptableWaves[numberOfWave].CountEnemies; i++)
        {
            _enemySpawn.HandleSpawn(numberOfWave);
            await Task.Delay(1000);
        }
    }
}
