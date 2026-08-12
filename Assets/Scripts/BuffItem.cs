using UnityEngine;
using StarterAssets;

public class BuffItem : ItemBase
{
    [Header("Random Appearances")]
    public Sprite[] possibleSprites;  // List of sprites for appearance
    private SpriteRenderer spriteRenderer;

    private BuffEffect buffEffect;

    private void Start()
    {
        // Initialize SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (possibleSprites != null && possibleSprites.Length > 0)
        {
            // Randomly pick a sprite
            Sprite randomSprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
            spriteRenderer.sprite = randomSprite;
        }
        else
        {
            Debug.LogWarning("No sprites assigned to BuffItem.");
        }

        // Attach or find BuffEffect on this GameObject
        buffEffect = GetComponent<BuffEffect>();
        if (buffEffect == null)
        {
            Debug.LogWarning("BuffEffect component missing on BuffItem.");
        }
    }

    public override void OnCollect(ThirdPersonController player)
    {




        if (buffEffect != null)
        {
            // Select a random buff when picked up
            buffEffect.SelectRandomBuff();

            Debug.Log($"[BuffItem] Collected Buff: {buffEffect.currentBuffName}");
            
            // Invoke the selected buff's action
            buffEffect.currentBuffAction.Invoke();
        }
    }
}
