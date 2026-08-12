using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class StaminaBarImage : MonoBehaviour
{
    public Image staminaFillImage;

    public void UpdateStamina(float normalizedValue)
    {
        staminaFillImage.fillAmount = Mathf.Clamp01(normalizedValue);
    }
}
