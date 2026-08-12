using UnityEngine;
using UnityEngine.UI;

public class DebuffUIHandler : MonoBehaviour
{
    public static DebuffUIHandler Instance { get; private set; }

    public Image debuffIconImage;

    private void Awake()
{
    Debug.Log("[DebuffUI] Awake called");

    if (Instance != null && Instance != this)
    {
        Debug.Log("[DebuffUI] Destroying duplicate");
        Destroy(gameObject);
        return;
    }

    Debug.Log("[DebuffUI] Setting Instance + DontDestroy");
    Instance = this;
    DontDestroyOnLoad(gameObject);
}

    public void UpdateDebuffIcon(Sprite icon)
{
    Debug.Log($"[DebuffUI] Update Icon called, incoming: {(icon != null ? icon.name : "NULL")}");
    Debug.Log($"[DebuffUI] debuffIconImage reference: {(debuffIconImage != null ? "OK" : "NULL")}");

    if (debuffIconImage != null)
    {
        debuffIconImage.sprite = icon;
        debuffIconImage.enabled = icon != null;
    }
    else
    {
        Debug.LogError("[DebuffUI] debuffIconImage is NULL, check assignment in Inspector!");
    }
}
}
