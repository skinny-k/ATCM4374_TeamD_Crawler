using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public enum QuestType { None, Meat, Nuts, Berries, Mushrooms }

    public QuestType Type { get; private set; } = QuestType.None;
    public int Value { get; private set; } = 0;

    public Quest(QuestType type, int value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return "(" + Type + ", " + Value + ")";
    }
}
