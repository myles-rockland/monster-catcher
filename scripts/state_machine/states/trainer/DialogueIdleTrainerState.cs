using Godot;

[GlobalClass]
public partial class DialogueIdleTrainerState : IdleTrainerState
{
    public override void Enter()
    {
        base.Enter();
        Trainer.facingDirection = Trainer.GetDirectionToCharacter(Trainer.Player);
        Trainer.ShowDialogue();
    }
}