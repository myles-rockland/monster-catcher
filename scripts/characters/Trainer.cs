using Godot;
using System;

public partial class Trainer : Character, IInteractable
{
    [Export] public DialogueIdleTrainerState DialogueIdleTrainerState { get; set; }

    public static Character characterLookingAtPlayer;

    public Player Player { get; set; }

    public bool IsDefeated { get; set; } = false;

    public void Interact()
    {
        StateMachine.ChangeState(DialogueIdleTrainerState);
    }
}
