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
        if (Player.movingDirection == default)
        {
            StateMachine.ChangeState("Idle");
        }
    }
}