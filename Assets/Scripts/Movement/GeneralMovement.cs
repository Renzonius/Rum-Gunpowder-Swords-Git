using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : BaseMovement, IMovable
{
    [SerializeField] private float _valorX;
    [SerializeField] private float _valorY;

    public float ValorX { get => _valorX; set => _valorX = value; }
    public float ValorY { get => _valorY; set => _valorY = value; }

    public void Move()
    {
        Vector2 movimiento = new Vector2(_valorX, _valorY).normalized * baseSpeed * Time.fixedDeltaTime;
        baseRb.MovePosition(baseRb.position + movimiento);
    }

}
