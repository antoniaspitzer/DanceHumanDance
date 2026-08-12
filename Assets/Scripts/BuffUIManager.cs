using UnityEngine;
using StarterAssets;

public class BuffUIManager : MonoBehaviour
{
    public static BuffUIManager Instance;

    public GameObject SpeedCanvas;
    public GameObject ReverseCanvas;
    public GameObject SlowCanvas;
    public GameObject SizeCanvas;
    public GameObject NoSightCanvas;
    public GameObject JumpCanvas;

    private void Awake()
    {
        DeactivateAll();
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DeactivateAll()
    {
        SpeedCanvas.SetActive(false);
        ReverseCanvas.SetActive(false);
        SlowCanvas.SetActive(false);
        SizeCanvas.SetActive(false);
        NoSightCanvas.SetActive(false);
        JumpCanvas.SetActive(false);
    }
}
