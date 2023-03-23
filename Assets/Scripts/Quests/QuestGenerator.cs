using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    [SerializeField] int _minValue = 1;
    [SerializeField] int _maxValue = 6;
    
    public Quest GenerateQuest(QuestTracker tracker)
    {
        // start a list of probabilities associated with quest types
        Dictionary<float, Quest.QuestType> _probabilities = new Dictionary<float, Quest.QuestType>();
        float runningTotal = 0;

        foreach (KeyValuePair<Quest.QuestType, List<Quest>> entry in tracker.CollectedQuests)
        {
            // set the probability of each quest type to its reciprocol of the percent of total quests that are that type
            // this ensures that quests that already have large counts are less likely to be generated
            float prob = tracker.TotalQuestCount / entry.Value.Count;
            _probabilities.Add(prob + runningTotal, entry.Key);
            runningTotal += prob;
        }

        // generate a random number from 0, to the maximum range of the totaled reciprocols
        // This approximates adjusting the probabilities to be in the range [0, 1] but is more efficient
        float randomNum = Random.Range(0.0f, runningTotal);
        Quest.QuestType type = Quest.QuestType.None;

        foreach (KeyValuePair<float, Quest.QuestType> entry in _probabilities)
        {
            // the first time the random num is less than the probability, we have found our quest type, and stop searching
            if (randomNum <= entry.Key)
            {
                type = entry.Value;
                break;
            }
        }

        // generate the random value of the quest
        int value = Random.Range(_minValue, _maxValue + 1);

        // return a new quest with the determined type and value
        // TO DO: assign the quest a location on the board to be placed at
        return new Quest(type, value);
    }

    // GenerateLocation()
    // {
    //     //
    // }
}
