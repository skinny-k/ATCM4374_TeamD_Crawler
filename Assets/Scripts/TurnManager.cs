using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [SerializeField] List<Player> _players = new List<Player>();
    int _turn = 0;

    public static event Action OnEnd;

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
        _players[0].Hand.ShowHand(true);
    }

    public Player CurrentPlayer()
    {
        return _players[_turn];
    }

    public void ShowCurrentHand(bool state)
    {
        _players[_turn].Hand.ShowHand(state);
    }

    public void AdvanceTurn()
    {
        if (_turn < _players.Count - 1)
        {
            _turn++;
        }
        else
        {
            _turn = 0;
        }

        ForceHideHands();
        _players[_turn].Hand.ShowHand(true);
    }

    void ForceHideHands()
    {
        foreach(Player player in _players)
        {
            player.Hand.ShowHand(false);
        }
    }

    void EndGame()
    {
        OnEnd?.Invoke();
    }
}
