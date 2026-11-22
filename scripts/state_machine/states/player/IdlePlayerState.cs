using Godot;

[GlobalClass]
public partial class IdlePlayerState : PlayerState
{
    [Export] public MovementPlayerState MovementPlayerState { get; set; }

    public override void Enter()
    {
        base.Enter();
        Player.UpdateAnimation("idle_");
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        Player.movingDirection = Input.GetVector("left", "right", "up", "down");

        if (Player.movingDirection != Vector2.Zero)
        {
            StateMachine.ChangeState(MovementPlayerState);
            return;
        }
    }
}
