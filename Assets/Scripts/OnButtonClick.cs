using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonClick : MonoBehaviour
{
    [SerializeField] AudioClip _buttonSFX;
    [SerializeField] float _delay = 1;
    [SerializeField] GameObject _objectToBeClosed;

    public void PlayButtonSound()
    {
        AudioHelper.PlayClip2D(_buttonSFX, 1);
    }

    public void CloseSetupWithDelay()
    {
        StartCoroutine(CloseSetup(_delay));
    }

    private IEnumerator CloseSetup(float delay)
    {
        _objectToBeClosed.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(delay);
        _objectToBeClosed.SetActive(false);
        _objectToBeClosed.transform.localScale = new Vector3(1, 1, 1);
       
    }

    public void GoToMainMenu()
    {
        StartCoroutine(MainMenuWithDelay(_delay));
    }

    private IEnumerator MainMenuWithDelay(float delay)
    {
        _objectToBeClosed.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(delay);
        _objectToBeClosed.SetActive(false);
        _objectToBeClosed.transform.localScale = new Vector3(1, 1, 1);
        SceneManager.LoadScene("MenuScene");
    }
}
