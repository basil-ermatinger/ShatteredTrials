using NUnit.Framework;
using Rpg2dSidescroller;
using System.Collections.Generic;

public class StateMachine
{
  public IState CurrentState { get; private set; }

  public List<IState> _states { get; set; }

  public StateMachine(List<IState> states)
  {
    _states = states;
  }

  public void Initialize(IState startingState)
  {
    CurrentState = startingState;
    startingState.Enter();
  }

  public void TransitionTo(IState nextState)
  {
    CurrentState.Exit();
    CurrentState = nextState;
    nextState.Enter();
  }

  public void Execute()
  {
    if(CurrentState is not null)
    {
      CurrentState.Update();
    }
  }
}
