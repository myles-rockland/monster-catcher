using Godot;

[GlobalClass]
public partial class ElementModifierData : Resource
{
    [Export] public Godot.Collections.Dictionary<ElementData, Godot.Collections.Dictionary<ElementData, float>> ModifierAgainstElement { get; set; }
}