using Godot;
using System;

[GlobalClass]
public partial class DialogueIdleTrainerState : IdleTrainerState
{
    [Export] public DialogueData MeetPlayerDialogue { get; set; }
    [Export] public DialogueData DefeatedDialogue { get; set; }
    [Export] public DialogueBox DialogueBox { get; set; }
    [Export] public IdleTrainerState IdleTrainerState { get; set; }
    [Export] public Event DialogueEndEvent { get; set; }


    private bool justEnteredState = false;

    public override void Enter()
    {
        Trainer.facingDirection = Trainer.GetDirectionToCharacter(Trainer.Player);
        base.Enter();

        ShowDialogue();

        justEnteredState = true;
        DialogueEndEvent.EventInvoked += OnDialogueEnd;
    }

    public override void Exit()
    {
        DialogueEndEvent.EventInvoked -= OnDialogueEnd;
        base.Exit();
    }

    private void OnDialogueEnd()
    {
        GD.Print("Entering battle");
        Trainer.IsDefeated = true;
        StateMachine.ChangeState(IdleTrainerState);
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        if (!justEnteredState)
        {
            if (Input.IsActionJustPressed("action"))
            {
                AdvanceDialogue();
            }
        }
        else
        {
            justEnteredState = false;
        }
    }

    private void ShowDialogue()
    {
        var dialogueData = (Trainer.IsDefeated) ? DefeatedDialogue : MeetPlayerDialogue;
        DialogueBox.SetData(dialogueData);

        DialogueBox.Visible = true;
    }

    private void AdvanceDialogue()
    {
        DialogueBox.AdvanceLine();
    }
}