using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bridgeSprite;

    private void Awake()
    {
        bridgeSprite = GetComponent<SpriteRenderer>();
    }

    //Metodo que utilizamos para activar el puente desde el script "BridgeController".
    public void ActivateBridge(float targetSize, float duration)
    {
        ChangeSize(targetSize, duration);
    }
    private async void ChangeSize(float targetSize, float duration)
    {
        await ChangeSizeAsync(targetSize, duration);
    }

    private async Task ChangeSizeAsync(float targetSize, float duration)
    {
        Vector3 initialScale = bridgeSprite.size;
        Vector3 targetScale = new Vector3(targetSize, initialScale.y, initialScale.z);

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            bridgeSprite.size = Vector3.Lerp(initialScale, targetScale, t);
            await Task.Yield();
        }

        // Asegurarse de que el tamaño final sea exactamente el objetivo.
        bridgeSprite.size = targetScale;
        CameraShake.Instance.Shake(0.5f, 0.2f, 0.5f);
    }
}
