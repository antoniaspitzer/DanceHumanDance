using UnityEngine;
using UnityEngine.UI;

public class HealthbarImage : MonoBehaviour
{
    public Image healthFillImage;

    public void UpdateHealth(float normalizedValue)
    {
        healthFillImage.fillAmount = Mathf.Clamp01(normalizedValue);
    }
}
