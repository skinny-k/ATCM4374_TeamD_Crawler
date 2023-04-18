using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    
    [SerializeField] GameObject _questEntryUI;
    [SerializeField] public int NumEasyQuests = 4;
    [SerializeField] public int EasyQuestPoints = 1;
    [SerializeField] Button EasyQuestButton;
    [SerializeField] public int NumMediumQuests = 4;
    [SerializeField] public int MediumQuestPoints = 2;
    [SerializeField] Button MediumQuestButton;
    [SerializeField] public int NumHardQuests = 4;
    [SerializeField] public int HardQuestPoints = 4;
    [SerializeField] Button HardQuestButton;

    public static event Action OnView;
    public static event Action OnClose;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddPlayerQuest(string difficulty)
    {
        TurnManager.Instance.CurrentPlayer().Score.AddQuest(difficulty);
        EnableQuestEntry(false);
    }

    public void DisableButton(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                EasyQuestButton.interactable = false;
                break;
            case "medium":
                MediumQuestButton.interactable = false;
                break;
            case "hard":
                HardQuestButton.interactable = false;
                break;
        }
    }

    public void EnableQuestEntry(bool state)
    {
        _questEntryUI.SetActive(state);
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
