using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewHandState : State
{
    GameSM _stateMachine;
    
    public ViewHandState(GameSM sm)
    {
        _stateMachine = sm;
    }

    void OnCardPlayed(CardObject card)
    {
        HandViewer.Instance.CloseHand(false);
        _stateMachine.ChangeState<TurnState>();
    }

    void OnFingerMove(Vector2 movement, Vector2 newPosition)
    {
        HandViewer.Instance.Scroll(movement);
    }
    
    void OnViewExited()
    {
        _stateMachine.ChangeState<TurnState>();
    }

    protected override void SubscribeToInput()
    {
        CardObject.OnPlay += OnCardPlayed;
        HandViewer.OnClose += OnViewExited;

        TouchManager.OnFingerMove += OnFingerMove;
    }

    protected override void UnsubscribeToInput()
    {
        CardObject.OnPlay -= OnCardPlayed;
        HandViewer.OnClose -= OnViewExited;

        TouchManager.OnFingerMove -= OnFingerMove;
    }
}
