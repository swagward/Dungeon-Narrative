using UnityEngine;

public class PuzzleRotator : Interactable
{
    public bool isSword;
    public override void Interact()
    {
        base.Interact();
        if (isSword)
        {
            gameObject.transform.Rotate(15, 0, 0);
        }
        else
        {
            gameObject.transform.Rotate(0, 15, 0);

        }
    }
}
