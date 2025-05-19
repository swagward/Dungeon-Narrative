using UnityEngine;

public class SwordPuzzleManager : MonoBehaviour
{
    public bool isSwordPuzzle;

    public GameObject[] swords;

    public GameObject lightBox;

    public GameObject doorToRemove;

    private void Update()
    {
        if (isSwordPuzzle)
        {
            if (Mathf.Approximately(swords[0].transform.eulerAngles.x, 45) 
                && swords[1].transform.eulerAngles.x == 0 
                && Mathf.Approximately(swords[2].transform.eulerAngles.x, 45))
            {
                Destroy(doorToRemove);
            }
        }
        else
        {
            if (Mathf.Approximately(lightBox.transform.eulerAngles.y, 30))
            {
                Debug.Log("complete");
                Destroy(doorToRemove);
            }
        }

    }
}
