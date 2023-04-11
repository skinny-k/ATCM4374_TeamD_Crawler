using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class CardObject : MonoBehaviour
{
    public CardData MyCardData = null;
    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _description;
    [SerializeField] GameObject _face;
    [SerializeField] Button _playButton;

    bool drawn = false;

    public event Action<CardObject> OnPlay;

    void OnValidate()
    {
        RenderData(true);
    }
    
    public void SetData(CardData newData)
    {
        MyCardData = newData;
        RenderData(true);
    }
    
    public void RenderData(bool state)
    {
        _title.text = "";
        _description.text = "";
        _face.SetActive(state);
        if (drawn)
        {
            _playButton.gameObject.SetActive(state);
        }

        if (state)
        {
            _title.text = MyCardData.Title;
            _description.text = MyCardData.Description;
        }
    }

    public void SendToHand()
    {
        TurnManager.Instance.CurrentPlayerHand().AddCard(this);
        Deck.Instance.EnableDraw(true);
        drawn = true;
        RenderData(TurnManager.Instance.CurrentPlayerHand().Visible);
    }

    public void Play()
    {
        OnPlay?.Invoke(this);
    }
}
