using Godot;

[GlobalClass]
public partial class DialogueBox : Panel
{
    [Export] public Label DialogueLabel { get; set; }

    public void SetData(DialogueData data)
    {
        DialogueLabel.Text = data.DialogueLines[0];
    }
}