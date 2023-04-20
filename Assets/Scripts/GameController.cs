using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    [SerializeField] string _gameplaySceneName;

    public string GameplaySceneName => _gameplaySceneName;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(_gameplaySceneName);
    }
}
