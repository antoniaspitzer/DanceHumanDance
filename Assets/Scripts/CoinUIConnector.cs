using UnityEngine;
using TMPro;

public class CoinUIConnector : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.SetCoinTextReference(coinText);
        }
    }
}