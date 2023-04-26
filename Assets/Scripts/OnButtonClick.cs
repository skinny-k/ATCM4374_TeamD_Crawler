using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    [SerializeField] AudioClip _buttonSFX;

    public void PlayButtonSound()
    {
        AudioHelper.PlayClip2D(_buttonSFX, 1);
    }
}
