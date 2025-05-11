using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D baseRb;
    [SerializeField] protected float baseSpeed = 5f;
}
