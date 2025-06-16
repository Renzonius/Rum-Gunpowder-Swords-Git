using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private bool isBigCannonActive = false;
    [SerializeField] private GameObject interactableObject;
    public void ShootBigCannon(InputAction.CallbackContext context)
    {
        if (context.performed && isBigCannonActive == true)
        {
            if (interactableObject.TryGetComponent(out BigCannon bigCannon))
            { 
                bigCannon.Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        interactableObject = tri.gameObject;
        if (interactableObject.TryGetComponent(out BigCannon bigCannon))
        {
            isBigCannonActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D tri)
    {
        if (tri.TryGetComponent(out BigCannon bigCannon))
        {
            isBigCannonActive = false;
        }
    }
}
