using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCannonBall : BaseProjectile
{
    [SerializeField] private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        baseMovement?.Move();
    }
    private void OnTriggerEnter2D(Collider2D tri)
    {
        if (tri.TryGetComponent(out IDamageable health))
        {
            health.TakeDamage(base._damage);
        }
        ResetPosition();
    }


    private void ResetPosition()
    {
        transform.localPosition = initialPosition; 
        gameObject.SetActive(false);
    }

}
