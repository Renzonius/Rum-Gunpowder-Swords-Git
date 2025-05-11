using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private FadeEffect _fadeEffect;

    private void Awake()
    {
        _fadeEffect = GetComponentInChildren<FadeEffect>();
    }

    
    private async void Start()
    {
        // Al iniciar cualquier escena se ejecuta el fade in.
        await _fadeEffect.FadeIn(_fadeDuration);
    }

    public void LoadScene(string sceneName)
    {
        LoadSceneTask(sceneName);
    }



    private async void LoadSceneTask(string sceneName)
    {
        await _fadeEffect.FadeOut(_fadeDuration);
        await LoadSceneAsync(sceneName); //Carga la escena de forma asíncrona.
    }

    /* 
    "SceneManager.LoadSceneAsync" tiene problemas con las unity tasks, 
    por lo que se crea una tarea que devuelve un Task<bool> para poder usar await.
    */
    private Task<Task<bool>> LoadSceneAsync(string sceneName)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        var taskCompletionSource = new TaskCompletionSource<bool>();

        asyncOperation.completed += _ => taskCompletionSource.SetResult(true);

        return Task.FromResult(taskCompletionSource.Task);
    }
}
