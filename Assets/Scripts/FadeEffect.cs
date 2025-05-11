using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;

    private void Awake()
    {
        _fadeImage = GetComponent<Image>();
    }

    private async Task DoFadeEffect(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime = 0f;
        float elapsedTimePercentage = 0f;

        while (elapsedTimePercentage < 1)
        {
            elapsedTimePercentage = elapsedTime / duration;
            _fadeImage.color = Color.Lerp(startColor, targetColor, elapsedTimePercentage);
            await Task.Yield(); // Null  
            elapsedTime += Time.deltaTime;
        }
    }

    public async Task FadeIn(float duration)
    {
        Color startColor = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 1);
        Color targetColor = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 0f);
        await DoFadeEffect(startColor, targetColor, duration);

        gameObject.SetActive(false);
    }

    public async Task FadeOut(float duration)
    {
        Color startColor = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 0f);
        Color targetColor = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 1f);
        gameObject.SetActive(true);
        await DoFadeEffect(startColor, targetColor, duration);
    }
}
