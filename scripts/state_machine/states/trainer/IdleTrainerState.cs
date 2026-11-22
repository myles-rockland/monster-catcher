using Godot;

[GlobalClass]
public partial class IdleTrainerState : TrainerState
{
    public override void Enter()
    {
        base.Enter();
        Trainer.UpdateAnimation("idle_");
    }
}