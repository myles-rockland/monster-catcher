using Godot;

public partial class EventListener : Node
{
    [Export] public Event Event { get; set; }

    public override void _EnterTree()
    {
        Event.EventInvoked += OnEventInvoked;
    }

    public override void _ExitTree()
    {
        Event.EventInvoked -= OnEventInvoked;
    }

    public virtual void OnEventInvoked() { }
}
