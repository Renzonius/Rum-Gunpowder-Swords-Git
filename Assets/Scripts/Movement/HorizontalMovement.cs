using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilizamos "baseRb.velocity" porque se invoca UNA SOLA VEZ para que el objeto haga todo el recorrido,
/// por ejemplo, en el metodo "Start()" y, 
/// de esta forma, no necesario estar actualizando continuamente la posicion del objeto
/// mediante el "FixedUpdate()".
/// </summary>
public class HorizontalMovement : BaseMovement, IMovable
{
    // "valueX" valor negativo hacia la izquierda, 
    // positivo para la derecha.
    [SerializeField] private float valueX = -1f;

    private void Start()
    {
        Move();
    }
    public void Move()
    {
        baseRb.velocity = new Vector2(valueX, 0).normalized * baseSpeed * Time.fixedDeltaTime;
    }

}
