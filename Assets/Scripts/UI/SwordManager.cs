using UnityEngine;
using UnityEngine.SceneManagement;
public class SwordManager : MonoBehaviour
{
    public bool firstSwordEvil;
    public bool secondSwordEvil;

    public void restart()
    {
        SceneManager.LoadScene("Menu");
    }

}
