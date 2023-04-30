using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    [SerializeField] string _gameplaySceneName;
    [SerializeField] AudioClip _playAgainSFX;
    [SerializeField] AudioClip _quitButton;

    private float _delay = 1;

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
        StartCoroutine(RestartDelay(_delay));
    }

    private IEnumerator RestartDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(_gameplaySceneName);
    }

    public void PlayAgainSFX()
    {
        AudioHelper.PlayClip2D(_playAgainSFX, .5f);
    }

    public void QuitButtonSFX()
    {
        AudioHelper.PlayClip2D(_quitButton, 1);
    }

}
