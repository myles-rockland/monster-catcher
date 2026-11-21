using Godot;

[GlobalClass]
public partial class MonsterStats : Resource
{
    [Export] public int MaxHP { get; set; }
    [Export] public float MaxEP { get; set; }
    [Export] public float Speed { get; set; }
}
