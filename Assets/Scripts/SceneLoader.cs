using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float _delay = .5f;    

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
