using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnState : State
{
    GameSM _stateMachine;
    
    public TurnState(GameSM sm)
    {
        _stateMachine = sm;
    }
    
    void OnCardDrawn(CardObject card)
    {
        _stateMachine.DrawCard.Card = card;
        _stateMachine.ChangeState<DrawCardState>();
    }

    void OnHandViewed()
    {
        _stateMachine.ChangeState<ViewHandState>();
    }

    void OnQuestViewOpened()
    {
        _stateMachine.ChangeState<QuestEnterState>();
    }

    void OnGameEnded()
    {
        _stateMachine.ChangeState<EndState>();
    }

    protected override void SubscribeToInput()
    {
        QuestManager.OnView += OnQuestViewOpened;
        HandViewer.OnView += OnHandViewed;
        SingleCardViewer.OnView += OnCardDrawn;
        TurnManager.OnEnd += OnGameEnded;
    }

    protected override void UnsubscribeToInput()
    {
        QuestManager.OnView -= OnQuestViewOpened;
        HandViewer.OnView -= OnHandViewed;
        SingleCardViewer.OnView -= OnCardDrawn;
        TurnManager.OnEnd -= OnGameEnded;
    }
}
