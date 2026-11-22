using Godot;

[GlobalClass]
public partial class MovementPlayerState : PlayerState
{
    [Export] public IdlePlayerState IdlePlayerState { get; set; }

    public override void Enter()
    {
        base.Enter();

        Player.movingDirection = Input.GetVector("left", "right", "up", "down");
        Player.Velocity = Player.movingDirection * Player.MoveSpeed;
        UpdateFacingDirection();
        Player.UpdateAnimation("walk_");
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        Player.movingDirection = Input.GetVector("left", "right", "up", "down");
        Player.Velocity = Player.movingDirection * Player.MoveSpeed;

        if (Player.movingDirection == Vector2.Zero)
        {
            StateMachine.ChangeState(IdlePlayerState);
            return;
        }

        UpdateFacingDirection();

        UpdateRayCastTargetPosition();

        Player.UpdateAnimation("walk_");
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        Player.MoveAndSlide();
    }

    private void UpdateFacingDirection()
    {
        Player.facingDirection = new Vector2I(Mathf.RoundToInt(Player.movingDirection.X), Mathf.RoundToInt(Player.movingDirection.Y));
    }

    private void UpdateRayCastTargetPosition()
    {
        var viewRayCastY = (Player.movingDirection.X == 0) ? Player.facingDirection.Y : 0;
        Player.ViewRayCast.TargetPosition = new Vector2(Player.facingDirection.X, viewRayCastY) * Player.ViewDistance;
    }
}