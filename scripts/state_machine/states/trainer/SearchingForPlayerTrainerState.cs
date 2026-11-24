using Godot;

[GlobalClass]
public partial class SearchingForPlayerTrainerState : TrainerState
{
    [Export] public Timer WatchTimer { get; set; }
    [Export] public NoticedPlayerTrainerState NoticedPlayerTrainerState { get; set; }

    public override void Enter()
    {
        base.Enter();
        WatchTimer.Start();
        Trainer.UpdateAnimation("idle_");
    }

    public override void Exit()
    {
        base.Exit();
        WatchTimer.Stop();
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        if (Trainer.ViewRayCast.GetCollider() is Player player && Trainer.characterLookingAtPlayer == null) // Second condition is currently used to stop this running twice... which won't ever happen
        {
            Trainer.characterLookingAtPlayer = Trainer;
            Trainer.Player = player;
            StateMachine.ChangeState(NoticedPlayerTrainerState);
        }
    }

    private void OnWatchTimerTimeout()
    {
        Trainer.facingDirection = new Godot.Collections.Array<Vector2I>() {
            Vector2I.Left,
            Vector2I.Right,
            Vector2I.Up,
            Vector2I.Down,
        }
        .PickRandom();

        Trainer.ViewRayCast.TargetPosition = 
            new Vector2(Trainer.facingDirection.X, Trainer.facingDirection.Y) * Trainer.ViewDistance;

        Trainer.UpdateAnimation("idle_");
    }
}
