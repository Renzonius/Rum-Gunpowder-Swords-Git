using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateEnemyBase : MonoBehaviour, IDamageable
{
    private IMovable _movement;

    [Header("ENEMY SETTINGS")]
    [SerializeField] private int _life = 100;
    [SerializeField] private int _scoreValue = 100;

    private void Awake()
    {
        TryGetComponent(out _movement);
    }
    public void TakeDamage(int damageValue)
    {
        {
            _life = Mathf.Max(_life - damageValue, 0);
            if (_life <= 0)
            {
                //Restar pirata a la oleada.
                //Actualizar el puntaje del jugador.

                //CancelInvoke("Desactivar");
                //pool.RegresarObjeto(this);
            }
        }
    }
}

