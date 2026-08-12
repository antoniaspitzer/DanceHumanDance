using TMPro;
using UnityEngine;

public class CharismaManager : MonoBehaviour
{
    public static CharismaManager Instance;

    public int charisma = 0;
    public TextMeshProUGUI charismaText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCharisma(int amount = 1)
    {
        charisma += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (charismaText != null)
        {
            charismaText.text = "Charisma: " + charisma;
        }
    }
}