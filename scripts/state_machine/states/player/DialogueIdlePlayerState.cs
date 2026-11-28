using Godot;

[GlobalClass]
public partial class DialogueIdlePlayerState : ForcedIdlePlayerState
{
    [Export] public Event DialogueEndEvent { get; set; }
    [Export] public IdlePlayerState IdlePlayerState { get; set; }

    public override void Enter()
    {
        base.Enter();
        DialogueEndEvent.EventInvoked += OnDialogueEndEvent;
    }

    public override void Exit()
    {
        DialogueEndEvent.EventInvoked -= OnDialogueEndEvent;
        base.Exit();
    }

    private void OnDialogueEndEvent()
    {
        StateMachine.ChangeState(IdlePlayerState);
    }
}