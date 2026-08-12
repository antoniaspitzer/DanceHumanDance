using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using System.Collections;
public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager Instance;
    AudioManager audioManager;


    [Header("UI")]
    public TMP_Text descriptionText;      // Beschreibungsfeld (TextMeshPro!)
    public GameObject descriptionPanel;   // Das Panel, das Text + Buy Button enthält
    public Button buyButton;              // Button für Kauf

    private ShopItem currentItem;


    void Start()
    {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
    }
    private void Awake()
    {
        // Singleton setzen
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Panel standardmäßig ausblenden
        if (descriptionPanel != null)
            descriptionPanel.SetActive(false);

        // Button-Click-Listener setzen
        if (buyButton != null)
            buyButton.onClick.AddListener(BuyCurrentItem);
    }

    // Vom ShopItemButton aufgerufen
    public void SelectItem(ShopItem item)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        currentItem = item;

        if (descriptionPanel != null)
            descriptionPanel.SetActive(true);

        if (descriptionText != null)
            descriptionText.text = item.description;
    }

    // Wird vom Buy-Button ausgelöst
    public void BuyCurrentItem()
{
    if (currentItem == null) return;

    if (CoinManager.Instance != null && CoinManager.Instance.TrySpendCoins(15))
    {
        HealthSystem stats = FindObjectOfType<HealthSystem>();
        if (stats != null)
        {
            switch (currentItem.effectType)
            {
                case ShopItem.ItemEffectType.IncreaseMaxHealth:
                    stats.maxHealth += currentItem.value;
                    stats.currentHealth = Mathf.Min(stats.currentHealth, stats.maxHealth);
                    break;
                case ShopItem.ItemEffectType.RegenOverTime:
                    stats.StartRegen(currentItem.value, currentItem.duration);
                    break;
            }
        }

        if (descriptionPanel != null)
            descriptionPanel.SetActive(false);

        currentItem = null;
    }
    else
    {
        Debug.Log("Nicht genug Coins!");

        audioManager = FindObjectOfType<AudioManager>();
        // AudioManager finden und notEnoughMoney abspielen
        audioManager.PlaySFX(audioManager.notEnoughMoney, 0.8f);
    }
}
}
