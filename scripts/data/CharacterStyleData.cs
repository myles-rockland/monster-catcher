using Godot;

[GlobalClass]
public partial class CharacterStyleData : Resource
{
    [Export(PropertyHint.File, "*.png")] public string Texture { get; set; }
}