using UnityEngine;

public class SwordPuzzleManager : MonoBehaviour
{
    public bool isSwordPuzzle;

    public GameObject[] swords;

    public GameObject[] lightBox;

    public GameObject doorToRemove;

    private void Update()
    {

        if (isSwordPuzzle)
        {
            if (swords[0].transform.eulerAngles.x == 45 && swords[1].transform.eulerAngles.x == 0 && swords[2].transform.eulerAngles.x == 45)
            {
                Destroy(doorToRemove);
            }
        }
        else
        {
            
            if (lightBox[0].transform.eulerAngles.y > 29 || lightBox[0].transform.eulerAngles.y < 31)
            {
                Debug.Log("light 0");
            }
            if ((lightBox[0].transform.eulerAngles.y > 29 || lightBox[0].transform.eulerAngles.y < 31) && lightBox[1].transform.eulerAngles.y == 330)
            {
                Debug.Log("complete");
                Destroy(doorToRemove);
            }
        }

    }
}
