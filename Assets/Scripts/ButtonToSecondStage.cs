using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToSecondStage : MonoBehaviour
{
    // This method can be assigned to a UI Button's OnClick event
    public void LoadSecondStage()
    {
        SceneManager.LoadScene("secondStage");
    }
}
