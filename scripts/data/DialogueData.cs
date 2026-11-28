using Godot;

[GlobalClass]
public partial class DialogueData : Resource
{
    [Export] public string[] DialogueLines { get; set; }
}
