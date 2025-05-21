using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateEnemyBase : MonoBehaviour, IDamageable, IPoolable
{
    private IMovable _movement;
    protected ObjectPool<PirateEnemyBase> basePool;

    [Header("ENEMY SETTINGS")]
    [SerializeField] private int _health = 100;
    [SerializeField] private int _scoreValue = 100;

    private void Awake()
    {
        TryGetComponent(out _movement);
    }
    public void TakeDamage(int damageValue)
    {
        {
            _health = Mathf.Max(_health - damageValue, 0);
            if (_health <= 0)
            {
                WaveController.Instance.subtractEnemy();
                //Actualizar el puntaje del jugador.

                CancelInvoke("Deactivate");
                basePool.ReturnObject(this);
            }
        }
    }
    public void Activate()
    {
        gameObject.SetActive(true);
        _movement?.Move();
        Invoke("Deactivate", 10f);
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void SetPool(ObjectPool<PirateEnemyBase> pool)
    {
        basePool = pool;
    }
}

