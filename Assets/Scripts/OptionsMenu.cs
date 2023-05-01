using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject _objectToBeOn;
    [SerializeField] GameObject _objectToBeOff;
    
    [SerializeField] AudioClip _backButtonSFX;

    [SerializeField] float _delay = 1f;

    private Vector3 _scaleTo1 = new Vector3(1, 1, 1);

    public void QuitOptions()
    {
        StartCoroutine(QuitOptionsWithDelay(_delay, _objectToBeOn, _objectToBeOff));
    }

    private IEnumerator QuitOptionsWithDelay(float delay, GameObject on, GameObject off)
    {
        AudioHelper.PlayClip2D(_backButtonSFX, 2);
        off.GetComponent<Animation>().Play();               
        yield return new WaitForSeconds(delay);
        on.SetActive(true);
        off.SetActive(false);
        off.transform.localScale = _scaleTo1;
    }

    public void BackButtonSound()
    {
        

    }

    public void ButtonTouchAnim()
    {
        GetComponent<Animation>().Play();
    }

}
