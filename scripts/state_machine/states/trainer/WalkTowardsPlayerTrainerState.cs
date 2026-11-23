using Godot;

[GlobalClass]
public partial class WalkTowardsPlayerTrainerState : TrainerState
{
    [Export] public float StopRadius { get; set; } = 24.0f;
    [Export] public IdleTrainerState IdleTrainerState { get; set; }

    public Player Player { get; set; }

    public override void Enter()
    {
        base.Enter();
        Trainer.movingDirection = Trainer.GetDirectionToCharacter(Player);
        Trainer.Velocity = Trainer.movingDirection * Trainer.MoveSpeed;
        GD.Print($"WalkTowardsPlayer Enter: Direction is {Trainer.movingDirection}");
        Trainer.UpdateAnimation("walk_");
    }

    public override void Exit()
    {
        base.Exit();
        Trainer.movingDirection = Vector2.Zero;
        Trainer.Velocity = Trainer.movingDirection * Trainer.MoveSpeed;
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        Trainer.UpdateAnimation("walk_");

        if (Trainer.Position.DistanceSquaredTo(Player.Position) < StopRadius * StopRadius)
        {
            StateMachine.ChangeState(IdleTrainerState);
        }
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        Trainer.MoveAndSlide();
    }
}
