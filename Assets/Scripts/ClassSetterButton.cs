using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Button))]
public class ClassSetterButton : MonoBehaviour
{
    [SerializeField] Quest.QuestType type = Quest.QuestType.None;
    [SerializeField] bool randomizeClass = false;

    public static event Action<Quest.QuestType> Set;
    public static event Action Randomize;

    // a helper function to invoke events with complex types (in this case Quest.QuestType),
    // since UnityEvents ordinarily only support booleans, numerical types and strings as input
    
    public void OnClick()
    {
        if (randomizeClass)
        {
            Randomize?.Invoke();
        }
        else
        {
            Set?.Invoke(type);
        }
    }
}
