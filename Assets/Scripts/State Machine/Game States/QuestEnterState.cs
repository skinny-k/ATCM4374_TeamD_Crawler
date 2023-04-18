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

    void ReturnToPlayerTurn()
    {
        _stateMachine.ChangeState<TurnState>();
    }
    
    protected override void SubscribeToInput()
    {
        QuestManager.OnClose += ReturnToPlayerTurn;
    }

    protected override void UnsubscribeToInput()
    {
        QuestManager.OnClose -= ReturnToPlayerTurn;
    }
}
