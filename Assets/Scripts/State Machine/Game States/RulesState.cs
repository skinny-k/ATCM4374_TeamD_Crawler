using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesState : State
{
    GameSM _stateMachine;
    
    public RulesState(GameSM sm)
    {
        _stateMachine = sm;
    }
    
    void OnViewClosed()
    {
        _stateMachine.ChangeState<TurnState>();
    }
    
    protected override void SubscribeToInput()
    {
        RulesManager.OnClose += OnViewClosed;
    }

    protected override void UnsubscribeToInput()
    {
        RulesManager.OnClose += OnViewClosed;
    }
}
