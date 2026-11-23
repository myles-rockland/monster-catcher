using Godot;

public partial class ChangePlayerStateEventListener : EventListener
{
    [Export] public Player Player { get; set; }
    [Export] public PlayerState StateToChangeTo { get; set; }

    public override void OnEventInvoked()
    {
        base.OnEventInvoked();
        Player.StateMachine.ChangeState(StateToChangeTo);
    }
}
