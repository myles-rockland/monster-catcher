using Godot;

public abstract partial class PlayerState : State
{
    [Export] public Player Player { get; set; }
}
