using Godot;

[GlobalClass]
public partial class IdlePlayerState : PlayerState
{

    [Export] public MovementPlayerState MovementPlayerState { get; set; }

    [Export] public TrainerNoticedPlayerEvent TrainerNoticedPlayerEvent { get; set; }
    [Export] public DialogueIdlePlayerState DialogueIdlePlayerState { get; set; }

    public override void Enter()
    {
        base.Enter();
        Player.UpdateAnimation("idle_");
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

        if (Player.movingDirection != Vector2.Zero)
        {
            StateMachine.ChangeState(MovementPlayerState);
            return;
        }
    }
}
