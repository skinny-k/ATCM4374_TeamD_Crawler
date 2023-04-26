using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float _delay = .5f;
    [SerializeField] AudioClip _startButtonSound;
    [SerializeField] AudioClip _quitButtonSound;
        
    public void StartButtonSound()
    {
        AudioHelper.PlayClip2D(_startButtonSound, 1);
        
    }

    public void QuitButtonSound()
    {
        AudioHelper.PlayClip2D(_quitButtonSound, 1);

    }

    public void ButtonTouchAnim()
    {
        GetComponent<Animation>().Play();
    }
       

    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadSceneDelay(_delay, sceneName));
    }

    private IEnumerator LoadSceneDelay(float delay, string scene)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameWithDelay(_delay));
    }

    private IEnumerator ExitGameWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }

}
