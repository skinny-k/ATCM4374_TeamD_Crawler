using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    [SerializeField] GameObject _cardVisuals;
    [SerializeField] Vector2 _distBetweenCards = new Vector2(125, 0);
    [SerializeField] GameObject _showButton;
    [SerializeField] GameObject _hideButton;

    public bool Visible { get; private set; } = false;

    List<CardObject> _cards = new List<CardObject>();

    public void EnableHand(bool state)
    {
        _showButton.SetActive(state);
        _hideButton.SetActive(false);
    }
    
    public void ShowHand(bool state)
    {
        Visible = state;
        foreach (CardObject card in _cards)
        {
            card.RenderData(state);
        }
    }

    public void AddCard(CardObject card)
    {
        _cards.Add(card);
        card.OnPlay += PlayCard;

        RectTransform cardTransform = card.GetComponent<RectTransform>();
        cardTransform.SetParent(_cardVisuals.transform);
        cardTransform.localRotation = Quaternion.Euler(Vector3.zero);
        cardTransform.anchoredPosition = _cardVisuals.GetComponent<RectTransform>().anchoredPosition + _distBetweenCards * (_cards.Count - 1);
    }

    public void RemoveCard(CardObject card)
    {
        _cards.Remove(card);
        card.OnPlay -= PlayCard;
    }

    public void PlayCard(CardObject card)
    {
        RemoveCard(card);
        Destroy(card.gameObject);
    }
}
