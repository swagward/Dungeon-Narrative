using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue Lines", fileName = "Dialogue Lines")]
public class DialogueLines : ScriptableObject
{
    public string speakerName;
    [TextArea(2,5)]
    public string[] lines;
}
