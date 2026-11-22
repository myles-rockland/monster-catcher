using Godot;
using System;

public partial class Trainer : Character
{
    [Export] public Timer WalkWaitTimer { get; set; }
    [Export] public Player Player { get; set; }
    [Export] public int StopRadius { get; set; } = 24;

    protected static Character characterLookingAtPlayer;

    //public override void _Process(double delta)
    //{
    //    if (ViewRayCast.GetCollider() is Player && characterLookingAtPlayer == null)
    //    {
    //        characterLookingAtPlayer = this;
    //        WalkWaitTimer.Start();
    //    }

    //    Animate();

    //    if (movingDirection != default)
    //    {
    //        if (Position.DistanceTo(Player.Position) < StopRadius)
    //        {
    //            movingDirection = Vector2.Zero;
    //        }
    //        Move();
    //    }
    //}

    private void OnWatchTimerTimeout()
    {
        facingDirection = new Godot.Collections.Array<Vector2I>() { 
            Vector2I.Left,
            Vector2I.Right,
            Vector2I.Up,
            Vector2I.Down,
        }.PickRandom();

        ViewRayCast.TargetPosition = new Vector2(facingDirection.X, facingDirection.Y) * ViewDistance;
    }

    private void OnWalkWaitTimerTimeout()
    {
        //movingDirection = GetDirectionToCharacter(Player);
        GD.Print($"WaitWaitTimerTimeout: Direction is {movingDirection}");
    }
}
