using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateEnemyA : PirateEnemyBase
{
    //Manejamos los layers de colisiones y excluimos al jugador.
    private void OnTriggerEnter2D(Collider2D tri)
    {
        if (tri.CompareTag("PlayerShip"))
        {
            WaveController.Instance.subtractEnemy();
            base.CancelInvoke("Deactivate");
            basePool.ReturnObject(this);
        }
    }
}
