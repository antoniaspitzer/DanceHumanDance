using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToFirstStage : MonoBehaviour
{
    // This method can be assigned to a UI Button's OnClick event
    public void LoadFirstStage()
    {
        SceneManager.LoadScene("firstStage");
    }
}

