using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private bool _canShoot = true;

    public bool CanShoot { get => _canShoot; set => _canShoot = value; }

    [SerializeField] private Animator _animator;

    private void Awake()
    {
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if ((_canShoot) && context.phase == InputActionPhase.Performed)
        {
            _animator.SetTrigger("Attack");
            playerBulletPrefab.transform.position = bulletSpawnPoint.position;
            playerBulletPrefab.SetActive(true);
            _canShoot = false;
        }
    }

}
