using Godot;
using System;

public partial class Trainer : Character, IInteractable
{
    [Export] public DialogueData DialogueData { get; set; }
    [Export] public DialogueBox DialogueBox { get; set; }
    [Export] public DialogueIdleTrainerState DialogueIdleTrainerState { get; set; }
    public static Character characterLookingAtPlayer;

    public Player Player { get; set; }

    public void ShowDialogue()
    {
        DialogueBox.SetData(DialogueData);
        DialogueBox.Visible = true;
    }

    public void HideDialogue()
    {
        DialogueBox.Visible = false;
    }

    public void Interact()
    {
        StateMachine.ChangeState(DialogueIdleTrainerState);
    }
}
