using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Shop Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    [TextArea] public string description;
    public Sprite icon;

    public enum ItemEffectType { IncreaseMaxHealth, RegenOverTime }
    public ItemEffectType effectType;
    public float value;
    public int cost = 15;
    public float duration;
    
}
