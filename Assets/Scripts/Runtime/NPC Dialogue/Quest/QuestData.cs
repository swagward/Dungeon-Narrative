using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest", order = 1)]
public class QuestData : ScriptableObject
{
    public string questName;
    [TextArea(2,4)] public string questDescription;
    public string requiredItemName;
}
