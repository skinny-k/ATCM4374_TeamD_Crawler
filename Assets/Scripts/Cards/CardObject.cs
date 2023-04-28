using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class CardObject : MonoBehaviour
{
    public CardData CurrentCardData = null;
    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _description;
    [SerializeField] GameObject _face;
    [SerializeField] Button _playButton;

    bool drawn = false;

    public static event Action<CardObject> OnDraw;
    public static event Action<CardObject> OnPlay;

    void OnValidate()
    {
        RenderData(true);
    }

    public void OnTapped()
    {
        if (drawn)
        {
            HandViewer.Instance.ViewHand();
        }
    }
    
    public void SetData(CardData newData)
    {
        CurrentCardData = newData;
        RenderData(true);
    }
    
    public void RenderData(bool state)
    {
        _title.text = "";
        _description.text = "";
        _face.SetActive(state);
        GetComponent<Button>().enabled = state;

        if (state && CurrentCardData != null)
        {
            _title.text = CurrentCardData.Title;
            _description.text = CurrentCardData.Description;
        }
    }

    public void SendToHand()
    {
        TurnManager.Instance.CurrentPlayer().Hand.AddCard(this);
        RenderData(TurnManager.Instance.CurrentPlayer().Hand.Shown);
        drawn = true;
        OnDraw?.Invoke(this);
    }

    public void Play()
    {
        OnPlay?.Invoke(this);
        Destroy(gameObject);
    }
}
