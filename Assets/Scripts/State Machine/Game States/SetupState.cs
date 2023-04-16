using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupState : State
{
    GameSM _stateMachine;
    bool _gameStarted = false;

    public SetupState(GameSM sm)
    {
        _stateMachine = sm;
    }
    
    public override void Tick()
    {
        if (_gameStarted)
        {
            SceneManager.LoadScene(GameController.Instance.GameplaySceneName);
        }
        else
        {
            _gameStarted = true;
            _stateMachine.ChangeState<TurnState>();
        }
    }
}
