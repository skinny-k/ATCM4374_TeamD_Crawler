using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSM : StateMachine
{
    public SetupState Setup { get; private set; }
    public TurnState Turn { get; private set; }
    public DrawCardState DrawCard { get; private set; }
    public ViewHandState ViewHand { get; private set; }
    public QuestEnterState Quest { get; private set; }
    // public DrawCardState DiceHold { get; private set; }
    // public ViewCardState DiceRoll { get; private set; }
    public EndState GameEnd { get; private set; }

    void Start()
    {
        Setup = new SetupState(this); _states.Add(Setup);
        Turn = new TurnState(this); _states.Add(Turn);
        DrawCard = new DrawCardState(this); _states.Add(DrawCard);
        ViewHand = new ViewHandState(this); _states.Add(ViewHand);
        Quest = new QuestEnterState(this); _states.Add(Quest);
        GameEnd = new EndState(this); _states.Add(GameEnd);

        ChangeState<SetupState>();
    }
}
