using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEnterState : State
{
    public CardObject Card = null;
    
    GameSM _stateMachine;
    
    public QuestEnterState(GameSM sm)
    {
        _stateMachine = sm;
    }
    
    void OnQuestConfirmed()
    {
        _stateMachine.ChangeState<TurnState>();
    }
    
    protected override void SubscribeToInput()
    {
        //
    }

    protected override void UnsubscribeToInput()
    {
        //
    }
}
