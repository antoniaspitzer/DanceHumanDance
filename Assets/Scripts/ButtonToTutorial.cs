using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToTutorial : MonoBehaviour
{
    // This method can be assigned to a UI Button's OnClick event
    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScreen");
    }
}

