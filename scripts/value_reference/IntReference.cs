using Godot;

[GlobalClass]
public partial class IntReference : Resource, IValueReference<int>
{
    private int value;

    [Export]
    public int Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
            EmitChanged();
        }
    }
}
