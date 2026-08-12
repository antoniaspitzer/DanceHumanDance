using UnityEngine;
using UnityEngine.SceneManagement;

public class TitelscreenLoader : MonoBehaviour
{
    private float timer = 0f;
    private float delay = 5f; // Zeit bis zum Wechsel
    private string sceneToLoad = "Titelscreen"; // Zielszene fest im Code

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
