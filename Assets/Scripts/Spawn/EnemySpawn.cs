using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<ObjectPool<PirateEnemyBase>> _spawnEnemyPools;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] PirateEnemyBase enemyPirate;

    public void HandleSpawn(int numberOfWave)
    {
        enemyPirate = _spawnEnemyPools[Random.Range(0, _spawnEnemyPools.Count)].GetObject();

        switch (numberOfWave)
        {
            case 0:
                ActivateMidSpawn(enemyPirate);
                break;
            case 1:
                ActivateDoubleSpawn(enemyPirate);
                break;
            case 2:
                ActivateTripleSpawn(enemyPirate);
                break;
            default:
                Debug.LogError("No hay mas oleadas disponibles");
                break;
        }
        enemyPirate.transform.rotation = Quaternion.identity;
    }

    public void ActivateMidSpawn(PirateEnemyBase enemyPirate)
    {
        enemyPirate.transform.position = spawnPoints[0].position;
    }

    public void ActivateDoubleSpawn(PirateEnemyBase enemyPirate)
    {
        enemyPirate.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    }

    public void ActivateTripleSpawn(PirateEnemyBase enemyPirate)
    {
        enemyPirate.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }
}
