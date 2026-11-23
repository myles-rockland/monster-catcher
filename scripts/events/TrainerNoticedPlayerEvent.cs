using Godot;

[GlobalClass]
public partial class TrainerNoticedPlayerEvent : Resource
{
    [Signal] public delegate void TrainerNoticedPlayerEventHandler(Trainer trainer, Player player);

    public void Invoke(Trainer trainer, Player player)
    {
        EmitSignalTrainerNoticedPlayer(trainer, player);
    }
}