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
    
    public override void Enter()
    {
        base.Enter();
        
        if (_gameStarted)
        {
            ReloadScene();
        }
    }
    
    void EnterGameplay()
    {
        _gameStarted = true;
        _stateMachine.ChangeState<TurnState>();
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(GameController.Instance.GameplaySceneName);
    }

    protected override void SubscribeToInput()
    {
        QuestManager.OnSetupClose += EnterGameplay;
    }

    protected override void UnsubscribeToInput()
    {
        QuestManager.OnSetupClose -= EnterGameplay;
    }
}
