using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    [SerializeField] GameObject _cardVisuals;
    [SerializeField] GameObject _colorField;
    [SerializeField] Vector2 _distBetweenCards = new Vector2(125, 0);
    [SerializeField] GameObject _showButton;
    [SerializeField] GameObject _hideButton;

    public List<CardObject> Cards = new List<CardObject>();
    public bool Shown { get; private set; } = false;
    public bool VisualsHidden { get; private set; } = false;

    [SerializeField] protected AudioClip _CardPlaySound;
    [SerializeField] protected AudioClip _addCardSound;
    [SerializeField] protected AudioClip _showCardSound;

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
        _colorField.SetActive(state);
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

        AddFeedback();

        RectTransform cardTransform = card.GetComponent<RectTransform>();
        cardTransform.SetParent(_cardVisuals.transform);
        cardTransform.localRotation = Quaternion.Euler(Vector3.zero);
        cardTransform.anchoredPosition = _distBetweenCards * (Cards.Count - 1);
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
            PlayFeedback();
        }
    }

    private void PlayFeedback()
    {
        if (_CardPlaySound != null)
        {
            AudioHelper.PlayClip2D(_CardPlaySound, 1f);
        }
    }

    private void AddFeedback()
    {
        if (_addCardSound != null)
        {
            AudioHelper.PlayClip2D(_addCardSound, 1f);
        }
    }

    private void ShowFeedback()
    {
        if (_showCardSound != null)
        {
            AudioHelper.PlayClip2D(_showCardSound, 1f);
        }
    }
}
