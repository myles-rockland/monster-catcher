using Godot;
using System;

[GlobalClass]
public partial class Player : Character
{
    [Export] public TrainerNoticedPlayerEvent TrainerNoticedPlayerEvent { get; set; }
    [Export] public ForcedIdlePlayerState ForcedIdlePlayerState { get; set; }

    public override void _EnterTree()
    {
        base._EnterTree();
        TrainerNoticedPlayerEvent.TrainerNoticedPlayer += OnTrainerNoticedPlayer;
    }

    public override void _ExitTree()
    {
        TrainerNoticedPlayerEvent.TrainerNoticedPlayer -= OnTrainerNoticedPlayer;
        base._ExitTree();
    }

    private void OnTrainerNoticedPlayer(Trainer trainer, Player player)
    {
        facingDirection = GetDirectionToCharacter(trainer);
        player.StateMachine.ChangeState(ForcedIdlePlayerState);
    }
}

