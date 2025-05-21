using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected int _damage = 100;
    public int Damage { get => _damage; set => _damage = value; }

    protected IMovable baseMovement;

    private void Awake()
    {
        TryGetComponent(out baseMovement);
    }

    private void Start()
    {
        baseMovement?.Move();
    }

}
