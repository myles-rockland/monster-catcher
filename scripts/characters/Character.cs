using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Character : CharacterBody2D
{
    [Export] public StateMachine StateMachine { get; set; }
    [Export] public AnimationPlayer AnimationPlayer { get; set; }
    [Export] public RayCast2D ViewRayCast { get; set; }
    [Export] public float MoveSpeed { get; set; } = 60;
    [Export] public float ViewDistance { get; set; } = 50;

    public Vector2 movingDirection;
    public Vector2I facingDirection;
    public Dictionary<Vector2I, string> directionToString = new()
    {
        { new Vector2I(0, 0), "down" },
        { new Vector2I(1, 0), "right" },
        { new Vector2I(-1, 0), "left" },
        { new Vector2I(0, -1), "up" },
        { new Vector2I(0, 1), "down" },
        { new Vector2I(1, 1), "right" },
        { new Vector2I(-1, 1), "left" },
        { new Vector2I(1, -1), "right" },
        { new Vector2I(-1, -1), "left" },
    };

    public override void _Process(double delta)
    {
        StateMachine.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        StateMachine.PhysicsUpdate(delta);
    }

    public void UpdateAnimation(string animationBaseName)
    {
        var animationToPlay = animationBaseName + directionToString[facingDirection];
        if (AnimationPlayer.CurrentAnimation != animationToPlay)
            AnimationPlayer.Play(animationToPlay);
    }

    public Vector2I GetDirectionToCharacter(Character character)
    {
        var directionFromMeToCharacter = (character.Position - Position).Normalized();
        return new Vector2I(Mathf.RoundToInt(directionFromMeToCharacter.X),
            Mathf.RoundToInt(directionFromMeToCharacter.Y));
    }
}
