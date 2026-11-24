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

        if (Input.IsActionJustPressed("action"))
        {
            if (Player.ViewRayCast.GetCollider() is IInteractable interactable)
            {
                if (interactable is Trainer trainer)
                {
                    trainer.Player = Player;
                }
                StateMachine.ChangeState(Player.ForcedIdlePlayerState);
                interactable.Interact();
                return;
            }
        }

        Player.movingDirection = Input.GetVector("left", "right", "up", "down");

        if (Player.movingDirection != Vector2.Zero)
        {
            StateMachine.ChangeState(MovementPlayerState);
            return;
        }
    }
}
