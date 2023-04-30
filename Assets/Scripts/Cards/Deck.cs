using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public static Deck Instance;
    
    [SerializeField] List<CardData> _cards = new List<CardData>();
    [SerializeField] CardObject _cardPrefab;
    [SerializeField] AudioClip _drawCardSFX;
    [SerializeField] AudioClip _cancelDraw;

    Queue<CardData> _deck = new Queue<CardData>();

    private float _delay = .5f;

    public static event Action<CardObject> OnDraw;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        for (int i = _cards.Count; i > 0; i--)
        {
            CardData card = _cards[Random.Range(0, i)];
            _cards.Remove(card);
            _deck.Enqueue(card);
        }
    }

    public void DrawCard()
    {
        StartCoroutine(DrawWithDelay(_delay));
    }

    private IEnumerator DrawWithDelay(float delay)
    {     
        if (TurnManager.Instance.CurrentPlayer().Hand.Cards.Count < TurnManager.Instance.CurrentPlayer().Hand.MaxHandSize)
        {
            CardObject draw = Instantiate(_cardPrefab);
            draw.transform.SetParent(transform.parent);
            draw.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            draw.SetData(_deck.Dequeue());
            draw.GetComponent<Animation>().Play();

            EnableDraw(false);
            if (_deck.Count <= 0)
            {
                gameObject.SetActive(false);
            }

            gameObject.GetComponent<Animation>().Play();

            yield return new WaitForSeconds(delay);
            OnDraw?.Invoke(draw);
        }
        else
        {
            Debug.Log("Max hand size acheived! Cannot draw card.");
        }
    }

    public void EnableDraw(bool state)
    {
        if (state)
        {
            CheckPlayerHandSize();
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void CheckPlayerHandSize()
    {
        if (TurnManager.Instance.CurrentPlayer().Hand.Cards.Count >= TurnManager.Instance.CurrentPlayer().Hand.MaxHandSize)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public IEnumerator CheckPlayerHandSizeAfterDelay()
    {
        yield return new WaitForSeconds(0.05f);
        CheckPlayerHandSize();
    }

    public void DrawConfirmSFX()
    {
        AudioHelper.PlayClip2D(_drawCardSFX, .5f);
    }

    public void CancelDrawFeedback()
    {
        AudioHelper.PlayClip2D(_cancelDraw, 2);
    }
}
