using UnityEngine;
using StarterAssets;
public class CoinItem : ItemBase
{
    public override void OnCollect(ThirdPersonController player)
{
    CoinManager.Instance?.AddCoins(1);
    Destroy(gameObject);
}
}

