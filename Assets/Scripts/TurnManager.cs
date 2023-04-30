using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [SerializeField] AudioClip _takeCardSFX;
    [SerializeField] public List<Player> Players = new List<Player>();
    int _turn = 0;

    public static event Action OnEnd;

    [SerializeField] protected AudioClip _TurnChangeSound;

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

        ForceHideHands();
        Players[0].Hand.ShowHand(true);
    }

    public Player CurrentPlayer()
    {
        return Players[_turn];
    }

    public void ShowCurrentHand(bool state)
    {
        Players[_turn].Hand.ShowHand(state);
    }

    public void AdvanceTurn()
    {
        if (_turn < Players.Count - 1)
        {
            _turn++;
            TurnChangeFeedback();
        }
        else
        {
            _turn = 0;
            TurnChangeFeedback();
        }

        ForceHideHands();
        Deck.Instance.CheckPlayerHandSize();
        Players[_turn].Hand.ShowHand(true);
    }

    void ForceHideHands()
    {
        foreach(Player player in Players)
        {
            player.Hand.ShowHand(false);
        }
    }

    void EndGame()
    {
        OnEnd?.Invoke();
    }

    private void TurnChangeFeedback()
    {
        if (_TurnChangeSound != null)
        {
            AudioHelper.PlayClip2D(_TurnChangeSound, .3f);
        }
    }

    public void TakeCardSFX()
    {
        AudioHelper.PlayClip2D(_takeCardSFX, 1);
    }

   
}
