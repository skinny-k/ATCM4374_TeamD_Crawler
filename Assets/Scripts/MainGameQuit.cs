using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameQuit : MonoBehaviour
{
    [SerializeField] AudioClip _quitButtonSound;

    [SerializeField] float _delay = 1;

    public void QuitButtonSound()
    {
        AudioHelper.PlayClip2D(_quitButtonSound, 1);

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
