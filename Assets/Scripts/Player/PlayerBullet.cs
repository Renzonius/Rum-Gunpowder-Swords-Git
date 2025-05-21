using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BaseProjectile
{
    [SerializeField] private PlayerShooting playerShooting;

    private void OnTriggerEnter2D(Collider2D tri)
    {
        if (tri.TryGetComponent(out IDamageable health))
        {
            health.TakeDamage(base._damage);
        }
        gameObject.SetActive(false);
        playerShooting.CanShoot = true;
    }

    private void OnEnable()
    {
        baseMovement?.Move();
    }
}
