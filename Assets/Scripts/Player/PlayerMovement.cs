using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : BaseMovement
{
    private float valueY;
    [SerializeField] private Animator animator;
    public void Move(InputAction.CallbackContext context)
    {
        valueY = context.ReadValue<Vector2>().y;

        SetearAnimacion();
    }

    private void SetearAnimacion()
    {
        if (valueY > 0)
        {
            //estaSubiendo = true;
            animator.SetBool("Up", true);
            animator.SetBool("Donw", false);
        }
        else if (valueY < 0)
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            //estaSubiendo = false;
        }
        else
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
    }

    private void FixedUpdate()
    {
        Vector2 movimiento = new Vector2(0, valueY).normalized * baseSpeed * Time.fixedDeltaTime;
        baseRb.MovePosition(baseRb.position + movimiento);
    }

}
