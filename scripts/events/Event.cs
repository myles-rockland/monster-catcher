using Godot;
using System;
using System.Collections.Generic;

public partial class Event : Resource
{
    public List<EventListener> EventListeners { get; set; }

}

public partial class EventListener : Node
{
    [Export] public Event Event { get; set; }

    public override void _EnterTree()
    {
        
    }

    public override void _ExitTree()
    {
        
    }

    public virtual void OnEventInvoked() { }
}
