using Godot;

public abstract partial class State : Node
{
    [Export] public StateMachine StateMachine { get; set; }

    protected float timeSinceEntry = 0.0f;
    protected float entryTime = 0.0f;

    public virtual bool CanEnter()
    {
        return true;
    }

    public virtual void Enter() 
    {
        entryTime = (float)Time.GetUnixTimeFromSystem();
    }

    public virtual void Update(double delta) 
    {
        timeSinceEntry = (float)Time.GetUnixTimeFromSystem() - entryTime;
    }

    public virtual void Exit() { }
}
