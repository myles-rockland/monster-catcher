using Godot;
using System;

[GlobalClass]
public partial class Player : Character
{
    public override void _Process(double delta)
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        movingDirection = Input.GetVector("left", "right", "up", "down");
        if (movingDirection != default)
        {
            facingDirection = new Vector2I(Mathf.RoundToInt(movingDirection.X), Mathf.RoundToInt(movingDirection.Y));
            var viewRayCastY = (movingDirection.X == 0) ? facingDirection.Y : 0;
            ViewRayCast.TargetPosition = new Vector2(facingDirection.X, viewRayCastY) * ViewDistance;
        }
    }
}
