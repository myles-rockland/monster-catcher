using Godot;

public partial class IdlePlayerState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        var animationToPlay = "idle_" + Player.directionToString[Player.facingDirection];
        Player.AnimationPlayer.Play(animationToPlay);
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        Player.movingDirection = Input.GetVector("left", "right", "up", "down");

        if (Player.movingDirection != Vector2.Zero)
        {
            StateMachine.ChangeState("Movement");
            return;
        }
    }
}
