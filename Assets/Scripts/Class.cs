using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Class : MonoBehaviour
{
    public static float CLASS_BONUS_MODIFIER = 2f;

    Quest.QuestType _bonusQuestType = Quest.QuestType.None;
    public Quest.QuestType BonusQuestType => _bonusQuestType;

    void OnEnable()
    {
        EnableClassInput();
    }

    void OnDisable()
    {
        DisableClassInput();
    }
    
    // not required for single-player, but these helper functions would be helpful for local multiplayer implementation
    void EnableClassInput()
    {
        ClassSetterButton.Randomize += RandomizeClass;
        ClassSetterButton.Set += SetClass;
    }
    void DisableClassInput()
    {
        ClassSetterButton.Randomize -= RandomizeClass;
        ClassSetterButton.Set -= SetClass;
    }
    
    // sets the bonus quest to a specific type
    public void SetClass(Quest.QuestType type)
    {
        _bonusQuestType = type;
        Debug.Log(_bonusQuestType);

        DisableClassInput();
    }
    
    // sets the bonus quest to a random type
    public void RandomizeClass()
    {
        // randomize the bonus quest type, as this is the only real attribute of the class
        // handling for rendering of class information should be able to hook in later.

        // this should only be happening once, so using a list and foreach loop should be fine
        List<Quest.QuestType> questTypes = new List<Quest.QuestType>();
        foreach (Quest.QuestType type in Enum.GetValues(typeof(Quest.QuestType)))
        {
            if (type != Quest.QuestType.None)
            {
                questTypes.Add(type);
            }
        }
        _bonusQuestType = questTypes[Random.Range(0, questTypes.Count)];
        Debug.Log(_bonusQuestType);

        DisableClassInput();
    }
}
