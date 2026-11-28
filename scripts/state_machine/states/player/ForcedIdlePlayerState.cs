using Godot;
using System;

[GlobalClass]
public partial class ForcedIdlePlayerState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        Player.UpdateAnimation("idle_");
    }
}
