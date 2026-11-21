using Godot;

[GlobalClass]
public partial class AttackData : Resource
{
    [Export] public string AttackName { get; set; }
    [Export] public bool IsOffensive { get; set; } // TODO: This means there is an offensive type of attack data. Could create a new class instead
    [Export] public int Cost { get; set; }
    [Export] public int Amount { get; set; }
    [Export] public ElementData Element { get; set; }
    [Export(PropertyHint.File, "*.png")] public string Texture { get; set; }
}
