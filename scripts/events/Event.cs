using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Event : Resource
{
    [Signal] public delegate void EventInvokedEventHandler();

    public void Invoke()
    {
        EmitSignalEventInvoked();
    }
}
