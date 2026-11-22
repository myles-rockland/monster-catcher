using Godot;

public partial class MovementPlayerState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        var animationToPlay = "walk_" + Player.directionToString[Player.facingDirection];
        Player.AnimationPlayer.Play(animationToPlay);
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        Player.movingDirection = Input.GetVector("left", "right", "up", "down");

        UpdateFacingDirection();

        UpdateRayCastTargetPosition();

        UpdateAnimation();

        if (Player.movingDirection == Vector2.Zero)
        {
            StateMachine.ChangeState("Idle");
            return;
        }
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

    private void UpdateAnimation()
    {
        var animationToPlay = "walk_" + Player.directionToString[Player.facingDirection];
        if (Player.AnimationPlayer.CurrentAnimation != animationToPlay)
            Player.AnimationPlayer.Play(animationToPlay);
    }

    public override void PhysicsUpdate(double delta)
    {
        Player.Velocity = Player.movingDirection * Player.MoveSpeed;
        Player.MoveAndSlide();
    }
}