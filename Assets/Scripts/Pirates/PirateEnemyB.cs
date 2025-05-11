using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateEnemyB : PirateEnemyBase
{
    //Manejamos los layers de colisiones y excluimos al jugador.
    private void OnTriggerEnter2D(Collider2D tri) 
    {
        if (tri.CompareTag("PlayerShip"))
        {
            //Restar pirata a la oleada.
            //CancelInvoke("Desactivar");
            //pool.RegresarObjeto(this);
        }
    }
}
