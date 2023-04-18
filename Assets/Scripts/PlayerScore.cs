using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    
    public int Score { get; private set; } = 0;

    public void Start()
    {
        _scoreText.text = Score + "";
    }
    
    public void AddQuest(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                Score += QuestManager.Instance.EasyQuestPoints;
                QuestManager.Instance.NumEasyQuests--;
                if (QuestManager.Instance.NumEasyQuests <= 0)
                {
                    QuestManager.Instance.DisableButton("easy");
                }
                break;
            case "medium":
                Score += QuestManager.Instance.MediumQuestPoints;
                QuestManager.Instance.NumMediumQuests--;
                if (QuestManager.Instance.NumMediumQuests <= 0)
                {
                    QuestManager.Instance.DisableButton("medium");
                }
                break;
            case "hard":
                Score += QuestManager.Instance.HardQuestPoints;
                QuestManager.Instance.NumHardQuests--;
                if (QuestManager.Instance.NumHardQuests <= 0)
                {
                    QuestManager.Instance.DisableButton("hard");
                }
                break;
        }

        _scoreText.text = Score + "";
    }
}
