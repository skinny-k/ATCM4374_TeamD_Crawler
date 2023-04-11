using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [SerializeField] int _players = 4;
    [SerializeField] List<CardHand> _playerHands = new List<CardHand>();
    int _turn = 0;

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
        ForceDisableHands();
        _playerHands[0].EnableHand(true);
    }

    public CardHand CurrentPlayerHand()
    {
        return _playerHands[_turn];
    }

    public void ShowCurrentHand(bool state)
    {
        _playerHands[_turn].ShowHand(state);
    }

    public void AdvanceTurn()
    {
        if (_turn < _players - 1)
        {
            _turn++;
        }
        else
        {
            _turn = 0;
        }

        ForceHideHands();
        ForceDisableHands();
        _playerHands[_turn].EnableHand(true);
    }

    void ForceHideHands()
    {
        foreach(CardHand playerHand in _playerHands)
        {
            playerHand.ShowHand(false);
        }
    }
    
    void ForceDisableHands()
    {
        foreach(CardHand playerHand in _playerHands)
        {
            playerHand.EnableHand(false);
        }
    }
}
