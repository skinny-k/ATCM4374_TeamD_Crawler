using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHand : MonoBehaviour
{
    [SerializeField] GameObject _cardVisuals;
    [SerializeField] Image _colorField;
    [SerializeField] Vector2 _distBetweenCards = new Vector2(125, 0);
    [SerializeField] GameObject _showButton;
    [SerializeField] GameObject _hideButton;

    public List<CardObject> Cards = new List<CardObject>();
    public bool Shown { get; private set; } = false;
    public bool VisualsHidden { get; private set; } = false;

    [SerializeField] protected AudioClip _cardPlaySound;
    [SerializeField] protected AudioClip _addCardSound;
    [SerializeField] protected AudioClip _showCardSound;

    void OnEnable()
    {
        CardObject.OnPlay += OnCardPlayed;
        SingleCardViewer.OnView += OnCardViewOpened;
        SingleCardViewer.OnClose += OnCardViewClosed;
    }

    void OnDisable()
    {
        CardObject.OnPlay -= OnCardPlayed;
        SingleCardViewer.OnView -= OnCardViewOpened;
        SingleCardViewer.OnClose -= OnCardViewClosed;
    }
    
    public void ShowHand(bool state)
    {
        Shown = state;
        _colorField.gameObject.SetActive(state);
        foreach (CardObject card in Cards)
        {
            card.RenderData(state);
        }
    }

    public void EnableVisuals(bool state)
    {
        VisualsHidden = state;
        _cardVisuals.SetActive(VisualsHidden);
        _colorField.gameObject.SetActive(state);
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

    void OnCardViewOpened(CardObject card)
    {
        _colorField.gameObject.SetActive(false);
    }

    void OnCardViewClosed()
    {
        if (TurnManager.Instance.CurrentPlayer().Hand == this)
        {
            _colorField.gameObject.SetActive(true);
        }
    }

    public void SetColorField(Color newColor)
    {
        _colorField.color = newColor;
    }

    private void PlayFeedback()
    {
        if (_cardPlaySound != null)
        {
            AudioHelper.PlayClip2D(_cardPlaySound, 1f);
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
