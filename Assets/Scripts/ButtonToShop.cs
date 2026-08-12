using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToShop : MonoBehaviour
{
    // This method can be assigned to a UI Button's OnClick event
    public void LoadSecondStage()
    {
        SceneManager.LoadScene("Shop");
    }
}
