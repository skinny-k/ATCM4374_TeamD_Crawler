using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCardViewer : MonoBehaviour
{
    public static SingleCardViewer Instance;

    [SerializeField] CardDisplay _cardDisplay;
    [SerializeField] GameObject _confirmDrawButton;
    
    public static event Action<CardObject> OnView;
    public static event Action OnClose;

    CardObject _currentCard;
    
    void OnEnable()
    {
        Deck.OnDraw += ViewCard;
    }

    void OnDisable()
    {
        Deck.OnDraw -= ViewCard;
    }
    
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
    
    public void ViewCard(CardObject card)
    {
        _currentCard = card;
        _currentCard.gameObject.SetActive(false);
        _cardDisplay.SetCard(_currentCard);
        _cardDisplay.gameObject.SetActive(true);
        _confirmDrawButton.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
        OnView?.Invoke(_currentCard);
    }

    public void SendCardToHand()
    {
        _currentCard.gameObject.SetActive(true);
        _currentCard.SendToHand();
        CloseView();
    }

    public void CloseView()
    {
        _currentCard.gameObject.SetActive(true);
        _cardDisplay.gameObject.SetActive(false);
        _confirmDrawButton.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        _cardDisplay.SetCard(null);
        OnClose?.Invoke();
    }
}
