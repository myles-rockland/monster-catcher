using Godot;

[GlobalClass]
public partial class DialogueBox : Panel
{
    [Export] public Label DialogueLabel { get; set; }
    [Export] public Event DialogueEndEvent { get; set; }

    public bool AtEndOfDialogue { get; private set; } = false;

    private DialogueData dialogueData;
    private int dialogueIndex = 0;

    public void SetData(DialogueData data)
    {
        dialogueIndex = 0;
        dialogueData = data;
        AtEndOfDialogue = false;
        DialogueLabel.Text = dialogueData.DialogueLines[dialogueIndex];
    }

    public void AdvanceLine()
    {
        if (dialogueIndex < dialogueData.DialogueLines.Length - 1)
        {
            dialogueIndex += 1;
            DialogueLabel.Text = dialogueData.DialogueLines[dialogueIndex];
        }
        else
        {
            Visible = false;
            DialogueEndEvent.Invoke();
        }
    }
}