using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesManager : MonoBehaviour
{
    public static event Action OnView;
    public static event Action OnClose;

    [SerializeField] GameObject _rulesUI;

    public void EnableRules(bool state)
    {
        _rulesUI.SetActive(state);
        
        if (state)
        {
            OnView?.Invoke();
        }
        else
        {
            OnClose?.Invoke();
        }
    }
}
