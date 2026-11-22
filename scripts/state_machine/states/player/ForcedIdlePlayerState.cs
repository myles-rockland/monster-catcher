public partial class ForcedIdlePlayerState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        var animationToPlay = "idle_" + Player.directionToString[Player.facingDirection];
        Player.AnimationPlayer.Play(animationToPlay);
    }
}
