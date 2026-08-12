using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int coins = 0;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // vermeide Duplikate
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // überlebt Szenenwechsel
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public bool TrySpendCoins(int cost)
    {
        if (coins >= cost)
        {
            coins -= cost;
            UpdateUI();
            return true;
        }
        else
        {
            Debug.Log("Nicht genug Münzen!");
            return false;
        }
    }

    public void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
        }
    }

    public void SetCoinTextReference(TextMeshProUGUI uiText)
    {
        coinText = uiText;
        UpdateUI();
    }
}
