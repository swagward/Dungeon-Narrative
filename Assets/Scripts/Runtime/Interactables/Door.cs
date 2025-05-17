using UnityEngine;

public class Door : Interactable
{
    public override void Use()
    {
        base.Use();
        Debug.Log("door shit");
    }
}