using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] AudioClip _buttonSFX;
    [SerializeField] GameObject _objectToBeOn;
    [SerializeField] GameObject _objectToBeOff;

    private float _delay = 1;
    private Vector3 _scaleTo1 = new Vector3(1, 1, 1);

    public void ButtonClicked()
    {
        StartCoroutine(OnBackButtonClick(_delay));
    }

    private IEnumerator OnBackButtonClick(float delay)
    {
        AudioHelper.PlayClip2D(_buttonSFX, 2);
        _objectToBeOn.SetActive(true);
        _objectToBeOff.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(delay);

        _objectToBeOff.SetActive(false);
        _objectToBeOff.transform.localScale = _scaleTo1;
    }

}
