using UnityEngine;

public class ShopEffectHandler : MonoBehaviour
{
    [SerializeField] private HealthSystem playerHealth;

    public void ApplyItemEffect(ShopItem item)
    {
        switch (item.effectType)
        {
            case ShopItem.ItemEffectType.IncreaseMaxHealth:
                playerHealth.IncreaseMaxHealth(item.value);
                break;

            case ShopItem.ItemEffectType.RegenOverTime:
                playerHealth.StartRegen(item.value, 120f);
                break;
        }

        Debug.Log("Effekt angewendet: " + item.name);
    }
}
