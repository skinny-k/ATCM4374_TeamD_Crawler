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
    }
    
    protected override void SubscribeToInput()
    {
        SingleCardViewer.OnClose += OnViewExited;
        // CardObject.OnDraw += OnCardDrawn;
    }

    protected override void UnsubscribeToInput()
    {
        SingleCardViewer.OnClose -= OnViewExited;
        // CardObject.OnDraw += OnCardDrawn;
    }
}
