using Godot;
using System;

public partial class Trainer : Character
{
    [Export] public DialogueData DialogueData { get; set; }
    public static Character characterLookingAtPlayer;
}
