using Godot;

[GlobalClass]
public partial class NoticedPlayerTrainerState : TrainerState
{
    [Export] public Timer WalkWaitTimer { get; set; }
    [Export] public WalkTowardsPlayerTrainerState WalkTowardsPlayerTrainerState { get; set; }
    [Export] public TrainerNoticedPlayerEvent TrainerNoticedPlayerEvent { get; set; }

    public Player Player { get; set; }

    public override void Enter()
    {
        base.Enter();
        WalkWaitTimer.Start();
        Trainer.UpdateAnimation("idle_");
        TrainerNoticedPlayerEvent.Invoke(Trainer, Player);
    }

    public override void Exit()
    {
        base.Exit();
        WalkWaitTimer.Stop();
    }

    private void OnWalkWaitTimerTimeout()
    {
        WalkTowardsPlayerTrainerState.Player = Player;
        StateMachine.ChangeState(WalkTowardsPlayerTrainerState);
    }
}
