using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleCardViewer : MonoBehaviour
{
    public static SingleCardViewer Instance;

    [SerializeField] CardDisplay _cardDisplay;
    [SerializeField] GameObject _confirmDrawButton;
    [SerializeField] Image _bg;
    
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

        Color bgColor = TurnManager.Instance.CurrentPlayer().PlayerColor;
        bgColor.a = 0.5f;
        _bg.color = bgColor;
        _bg.gameObject.SetActive(true);

        GetComponent<RectTransform>().rotation = Quaternion.Euler(TurnManager.Instance.CurrentPlayer().CardViewRotation);

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
        _bg.gameObject.SetActive(false);
        _cardDisplay.SetCard(null);
        OnClose?.Invoke();
    }
}
