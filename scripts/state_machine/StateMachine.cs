using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
    [Export] public State StartingState { get; set; }

    private State currentState;
    private Dictionary<string, State> states = new();

    public override void _Ready()
    {
        foreach (var node in GetChildren())
        {
            if (node is not State state)
                continue;

            state.StateMachine = this;
            states[state.Name] = state;
        }

        ChangeState(StartingState.Name);
    }

    public void ChangeState(string newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = states[newState];

        currentState.Enter();
    }

    public override void _Process(double delta)
    {
        currentState.Update(delta);
    }
}