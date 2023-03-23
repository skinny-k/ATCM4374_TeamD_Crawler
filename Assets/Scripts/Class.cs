using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    public static float CLASS_BONUS_MODIFIER = 2f;

    [SerializeField] Quest.QuestType _bonusQuestType = Quest.QuestType.None;
    public Quest.QuestType BonusQuestType => _bonusQuestType;
}
