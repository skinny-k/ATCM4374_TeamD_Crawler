using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesManager : MonoBehaviour
{
    public static event Action OnView;
    public static event Action OnClose;

    [SerializeField] GameObject _rulesUI;
    [SerializeField] AudioClip _buttonSFX;
    [SerializeField] AudioClip _backButtonSFX;

    public void EnableRules(bool state)
    {        
        _rulesUI.SetActive(state);
        
        if (state)
        {
            AudioHelper.PlayClip2D(_buttonSFX, 1);
            OnView?.Invoke();
        }
        else
        {
            AudioHelper.PlayClip2D(_backButtonSFX, 1);
            OnClose?.Invoke();
        }
    }


}
