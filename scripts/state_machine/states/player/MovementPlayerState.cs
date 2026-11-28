using Godot;

[GlobalClass]
public partial class MovementPlayerState : PlayerState
{
    [Export] public IdlePlayerState IdlePlayerState { get; set; }

    [Export] public TrainerNoticedPlayerEvent TrainerNoticedPlayerEvent { get; set; }
    [Export] public DialogueIdlePlayerState DialogueIdlePlayerState { get; set; }

    public override void Enter()
    {
        base.Enter();

        Player.movingDirection = Input.GetVector("left", "right", "up", "down");
        Player.Velocity = Player.movingDirection * Player.MoveSpeed;
        UpdateFacingDirection();
        Player.UpdateAnimation("walk_");
        TrainerNoticedPlayerEvent.TrainerNoticedPlayer += OnTrainerNoticedPlayer;
    }

    public override void Exit()
    {
        TrainerNoticedPlayerEvent.TrainerNoticedPlayer -= OnTrainerNoticedPlayer;
        base.Exit();
    }

    private void OnTrainerNoticedPlayer(Trainer trainer, Player player)
    {
        Player.facingDirection = Player.GetDirectionToCharacter(trainer);
        player.StateMachine.ChangeState(DialogueIdlePlayerState);
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
                StateMachine.ChangeState(DialogueIdlePlayerState);
                interactable.Interact();
                return;
            }
        }

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