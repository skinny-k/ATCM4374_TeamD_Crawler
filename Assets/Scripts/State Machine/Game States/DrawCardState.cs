using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardState : State
{
    public CardObject Card = null;
    
    GameSM _stateMachine;
    
    public DrawCardState(GameSM sm)
    {
        _stateMachine = sm;
    }

    void OnViewExited()
    {
        Card = null;
        _stateMachine.ChangeState<TurnState>();
        Deck.Instance.StartCoroutine(Deck.Instance.CheckPlayerHandSizeAfterDelay());
    }
    
    protected override void SubscribeToInput()
    {
        TouchManager.OnFingerUp += OnViewExited;
        TouchManager.OnFingerUp += SingleCardViewer.Instance.SendCardToHand;
        TouchManager.OnFingerUp += SingleCardViewer.Instance.CloseView;
    }

    protected override void UnsubscribeToInput()
    {
        TouchManager.OnFingerUp -= OnViewExited;
        TouchManager.OnFingerUp -= SingleCardViewer.Instance.SendCardToHand;
        TouchManager.OnFingerUp -= SingleCardViewer.Instance.CloseView;
    }
}
