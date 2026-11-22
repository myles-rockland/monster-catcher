using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class StateMachine : Node
{
    [Export] public State StartingState { get; set; }

    private State currentState;

    public override void _Ready()
    {
        foreach (var node in GetChildren())
        {
            if (node is not State state)
                continue;

            state.StateMachine = this;
        }

        ChangeState(StartingState);
    }

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter();
    }

    public void Update(double delta)
    {
        currentState.Update(delta);
    }

    public void PhysicsUpdate(double delta)
    {
        currentState.PhysicsUpdate(delta);
    }
}