using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopItemButton : MonoBehaviour
{
    public GameObject buyButton;
    public GameObject speechBubble;
    public ShopItem itemData;
    public Image iconImage;

    AudioManager audioManager;

    private bool buttonsVisible = false;

    private void Start()
{
    if (itemData != null && iconImage != null)
    {
        iconImage.sprite = itemData.icon;
    }

    // TEST: BuyButton sichtbar machen
    if (buyButton != null)
    {
        buyButton.SetActive(true);
        Debug.Log("BuyButton sichtbar gemacht im Start");
    }

    if (speechBubble != null)
    {
        speechBubble.SetActive(true);
    }

    GetComponent<Button>().onClick.AddListener(OnButtonClick);
}

    public void OnButtonClick()
{
    Debug.Log("OnButtonClick wurde ausgelöst!");

    // IMMER einschalten – nicht toggeln!
    buttonsVisible = true;

    if (buyButton != null) buyButton.SetActive(true);
    if (speechBubble != null) speechBubble.SetActive(true);

    // UI Beschreibung updaten
    if (ShopUIManager.Instance != null)
    {
        ShopUIManager.Instance.SelectItem(itemData);
    }
    
    audioManager = FindObjectOfType<AudioManager>();
    // AudioManager finden und shopButtonClick abspielen
    audioManager.PlaySFX(audioManager.shopButtonClick, 0.8f);

    Debug.Log("Item clicked: " + itemData.name);
    Debug.Log("Description: " + itemData.description);
}

    // Wird vom Buy-Button aufgerufen
    public void PurchaseItem()
    {
        FindAnyObjectByType<ShopEffectHandler>()?.ApplyItemEffect(itemData);

        audioManager = FindObjectOfType<AudioManager>();
        // AudioManager finden und itemPurchase abspielen
        audioManager.PlaySFX(audioManager.itemPurchase, 0.8f);
    }
}
