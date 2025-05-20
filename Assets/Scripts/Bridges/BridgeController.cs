using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private Bridge[] bridges;
    [SerializeField] private float tileMaxSize = 14f;
    [SerializeField] private float tileMinSize = 0f;

    //Metodo que tulizamos para ACTIVAR el puente desde el script "GameManager".
    public void ExtendBridge(float duration, int count)
    {
         ChangeBridgeSize(tileMaxSize, duration, count);
    }
    //Metodo que tulizamos para DESACTIVAR el puente desde el script "GameManager".
    public void CollapseBridge(float duration, int count)
    {
        ChangeBridgeSize(tileMinSize, duration, count);
    }

    private void ChangeBridgeSize(float targetSize, float duration, int count)
    {
        // Asegurarse de que el tama�o objetivo est� dentro de los l�mites.
        targetSize = Mathf.Clamp(targetSize, tileMinSize, tileMaxSize);

        // Limitar la cantidad de elementos a modificar al tama�o del arreglo.
        count = Mathf.Clamp(count, 0, bridges.Length);

        switch (count)
        {
            case 0:
                bridges[0].ActivateBridge(targetSize, duration);
                break;
            case 1:
                bridges[1].ActivateBridge(targetSize, duration);
                bridges[2].ActivateBridge(targetSize, duration);
                break;
            case 2:
                bridges[0].ActivateBridge(targetSize, duration);
                bridges[1].ActivateBridge(targetSize, duration);
                bridges[2].ActivateBridge(targetSize, duration);
                break;
            default:
                Debug.LogWarning("El n�mero de puentes a activar no es v�lido.");
            break;
        }
    }
}

