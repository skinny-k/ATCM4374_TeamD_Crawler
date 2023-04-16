using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    [SerializeField] GameObject _cardVisuals;
    [SerializeField] Vector2 _distBetweenCards = new Vector2(125, 0);
    [SerializeField] GameObject _showButton;
    [SerializeField] GameObject _hideButton;

    public List<CardObject> Cards = new List<CardObject>();
    public bool Shown { get; private set; } = false;
    public bool VisualsHidden { get; private set; } = false;

    void OnEnable()
    {
        CardObject.OnPlay += OnCardPlayed;
    }

    void OnDisable()
    {
        CardObject.OnPlay -= OnCardPlayed;
    }
    
    public void ShowHand(bool state)
    {
        Shown = state;
        foreach (CardObject card in Cards)
        {
            card.RenderData(state);
        }
    }

    public void EnableVisuals(bool state)
    {
        VisualsHidden = state;
        _cardVisuals.SetActive(VisualsHidden);
    }

    public void AddCard(CardObject card)
    {
        Cards.Add(card);

        RectTransform cardTransform = card.GetComponent<RectTransform>();
        cardTransform.SetParent(_cardVisuals.transform);
        cardTransform.localRotation = Quaternion.Euler(Vector3.zero);
        cardTransform.anchoredPosition = _cardVisuals.GetComponent<RectTransform>().anchoredPosition + _distBetweenCards * (Cards.Count - 1);
    }

    public void RemoveCard(CardObject card)
    {
        Cards.Remove(card);
    }

    public void OnCardPlayed(CardObject card)
    {
        if (Cards.Contains(card))
        {
            RemoveCard(card);
        }
    }
}
