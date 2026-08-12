using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using System.Collections; // Required for Coroutines

public class DamageUI : MonoBehaviour
{
    public Image damageOverlayImage; // Assign your damage overlay PNG here in the Inspector
    public float displayDuration = 0.2f; // How long the overlay is visible (in seconds)
    public float fadeDuration = 0.1f; // How long it takes for the overlay to fade out

    private Coroutine fadeRoutine; // To manage the fade coroutine

    void Start()
    {
        // Ensure the image is initially transparent/hidden
        if (damageOverlayImage != null)
        {
            Color currentColor = damageOverlayImage.color;
            currentColor.a = 0f; // Set alpha to 0 (fully transparent)
            damageOverlayImage.color = currentColor;
        }
        else
        {
            Debug.LogError("Damage Overlay Image not assigned! Please assign the Image component in the Inspector.");
        }
    }

    public void ShowDamageEffect()
    {
        if (damageOverlayImage == null)
        {
            Debug.LogError("Damage Overlay Image is null. Cannot show damage effect.");
            return;
        }

        // Stop any existing fade routine to prevent conflicts
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        // Immediately show the overlay at full opacity
        Color fullOpacity = damageOverlayImage.color;
        fullOpacity.a = 1f; // Set alpha to 1 (fully opaque)
        damageOverlayImage.color = fullOpacity;

        // Start the fade-out routine
        fadeRoutine = StartCoroutine(FadeOutDamageOverlay());
    }

    private IEnumerator FadeOutDamageOverlay()
    {
        // Wait for the initial display duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out over the fadeDuration
        float timer = 0f;
        Color startColor = damageOverlayImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // Target is fully transparent

        while (timer < fadeDuration)
        {
            damageOverlayImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure it's fully transparent at the end
        damageOverlayImage.color = endColor;
    }
}