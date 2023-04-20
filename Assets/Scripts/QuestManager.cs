using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    
    [Header("UI")]
    [SerializeField] GameObject _questEntryUI;
    [SerializeField] Button EasyQuestButton;
    [SerializeField] Button MediumQuestButton;
    [SerializeField] Button HardQuestButton;

    [Header("Quest Settings")]
    [SerializeField] public int NumEasyQuests = 4;
    [SerializeField] public int EasyQuestPoints = 1;
    [SerializeField] public int NumMediumQuests = 4;
    [SerializeField] public int MediumQuestPoints = 2;
    [SerializeField] public int NumHardQuests = 4;
    [SerializeField] public int HardQuestPoints = 4;
    [SerializeField] public int NumQuestItems = 4;

    [Header("Setup")]
    [SerializeField] int _numQuestTiles = 11;
    [SerializeField] TMP_Text _hardQuestText;
    [SerializeField] TMP_Text _mediumQuestText;
    [SerializeField] TMP_Text _easyQuestText;
    [SerializeField] TMP_Text _questItemText;

    [Header("Feedback")]
    [SerializeField] protected AudioClip _QuestButtonSound;
    [SerializeField] protected AudioClip _QuestAddSound;
    [SerializeField] protected AudioClip _CancelSound;

    public static event Action OnSetupClose;
    public static event Action OnView;
    public static event Action OnClose;
    public static event Action OnAllQuestsComplete;

    List<int> _questTiles = new List<int>();
    bool _hasQuests = true;

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

        SetupQuests();
    }

    public void SetupQuests()
    {
        for (int i = 1; i <= _numQuestTiles; i++)
        {
            _questTiles.Add(i);
        }
        
        _hardQuestText.text = GenerateTilesAsString(NumHardQuests);
        _mediumQuestText.text = GenerateTilesAsString(NumMediumQuests);
        _easyQuestText.text = GenerateTilesAsString(NumEasyQuests);
        _questItemText.text = GenerateTilesAsString(NumQuestItems);
    }

    public void CloseSetupUI()
    {
        OnSetupClose?.Invoke();
    }

    string GenerateTilesAsString(int amount)
    {
        string result = "";

        for (int i = 0; i < amount; i++)
        {
            if (_questTiles.Count > 0)
            {
                int tile = _questTiles[Random.Range(0, _questTiles.Count)];
                _questTiles.Remove(tile);
                result += tile;
                if (i < amount - 1)
                {
                    result += ", ";
                }
            }
        }

        return result;
    }

    public void AddPlayerQuest(string difficulty)
    {
        TurnManager.Instance.CurrentPlayer().ScoreKeeper.AddQuest(difficulty);
        EnableQuestEntry(false);
        QuestAddFeedback();
        if (_hasQuests)
        {
            OnClose?.Invoke();
        }
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

        if (EasyQuestButton.interactable == false &&
            MediumQuestButton.interactable == false &&
            HardQuestButton.interactable == false)
        {
            _hasQuests = false;
            OnAllQuestsComplete?.Invoke();
        }
    }

    public void EnableQuestEntry(bool state)
    {
        _questEntryUI.SetActive(state);
        if (state)
        {
            OnView?.Invoke();
            QuestButtonFeedback();
        }
    }

    private void QuestButtonFeedback()
    {
        if (_QuestButtonSound != null)
        {
            AudioHelper.PlayClip2D(_QuestButtonSound, 1f);
        }
    }

    private void QuestAddFeedback()
    {
        if (_QuestAddSound != null)
        {
            AudioHelper.PlayClip2D(_QuestAddSound, 1f);
        }
    }
}
