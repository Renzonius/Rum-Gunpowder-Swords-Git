using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;

    public void LoadScene(string sceneName)
    {
        _sceneController.LoadScene(sceneName);
    }
}
