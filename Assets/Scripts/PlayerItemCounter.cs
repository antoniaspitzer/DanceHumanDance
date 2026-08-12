using UnityEngine;
using TMPro; // Required for TextMeshProUGUI

public class PlayerItemCounter : MonoBehaviour
{
    public int itemCount = 0;
    public TextMeshProUGUI counterText; // Assign in Inspector

    private void Start()
    {
        UpdateCounterUI();

    }

    public void AddItem()
    {
        itemCount++;
        UpdateCounterUI();
    }

    private void UpdateCounterUI()
    {
        if (counterText != null)
        {
            counterText.text = "" + itemCount;
        }
    }
}

