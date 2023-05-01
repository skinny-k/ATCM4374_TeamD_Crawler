using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip _startButtonSound;
    [SerializeField] AudioClip _quitButtonSound;
    [SerializeField] AudioClip _music;

    [Header("Params")]
    [SerializeField] float _delay = 1;
    [SerializeField] float _musicVolume = .1f;

    [Header("GameObjects")]
    [SerializeField] GameObject _objectToBeOn;
    [SerializeField] GameObject _objectToBeOff;

    private Vector3 _scaleTo1 = new Vector3(1, 1, 1);


    private void Start()
    {
        MusicPlayer.Instance.PlayNewSong(_music,_musicVolume);
    }

    // Start button
    public void StartButtonSound()
    {
        AudioHelper.PlayClip2D(_startButtonSound, 1);
        
    }

    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadSceneDelay(_delay, sceneName));
    }

    private IEnumerator LoadSceneDelay(float delay, string scene)
    {
        _objectToBeOff.GetComponent<Animation>().Play();
        _objectToBeOn.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    // Quit Button
    public void QuitButtonSound()
    {
        AudioHelper.PlayClip2D(_quitButtonSound, 1);

    }

    public void ButtonTouchAnim()
    {
        GetComponent<Animation>().Play();
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

    // Options Button
    public void OptionsButton()
    {
        StartCoroutine(OnOptionsButtonClick(_delay));
    }

    private IEnumerator OnOptionsButtonClick(float delay)
    {
        StartButtonSound();
        _objectToBeOn.SetActive(true);
        _objectToBeOff.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(delay);               

        _objectToBeOff.SetActive(false);
        _objectToBeOff.transform.localScale = _scaleTo1;
    }

    public void ChangeMusicVolume(float volume)
    {
        MusicPlayer.Instance.UpdateMusicVolume(volume);
    }
   
}
