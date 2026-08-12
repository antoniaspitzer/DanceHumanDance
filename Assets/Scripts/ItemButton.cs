using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public GameObject buyButton;      // Der Kauf-Button
    public GameObject speechBubble;   // Die Sprechblase

    private bool buttonsVisible = false;

    void Start()
    {
        if (buyButton != null) buyButton.SetActive(false);
        if (speechBubble != null) speechBubble.SetActive(false);

        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        buttonsVisible = !buttonsVisible;

        if (buyButton != null) buyButton.SetActive(buttonsVisible);
        if (speechBubble != null) speechBubble.SetActive(buttonsVisible);
    }
}
