using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : State
{
    GameSM _stateMachine;
    
    public EndState(GameSM sm)
    {        
        _stateMachine = sm;        
    }
    
    void OnGameRestarted()
    {
        _stateMachine.ChangeState<SetupState>();
    }
}
