using Godot;
using System;

public abstract partial class TrainerState : State
{
    [Export] public Trainer Trainer { get; set; }
}