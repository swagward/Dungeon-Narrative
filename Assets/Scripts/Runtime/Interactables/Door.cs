using UnityEngine;

public class Door : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("door shit");
    }
}