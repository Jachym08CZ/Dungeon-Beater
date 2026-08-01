using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{    
    [Header("Xp")]

    public TMP_Text MaxXpText;
    public TMP_Text XpText;
    public Slider XpBar;

    [Header("Level")]
    public TMP_Text levelText;

    [Header("Health")]
    public Slider HealthSlider;

    [SerializeField] private PlayerLevel playerLevel;
    [SerializeField] private BaseHealthScript baseHealth;

    private void Start()
    {
        playerLevel.OnXpChange += RefreshXp;
        playerLevel.OnLeveLUp += RefreshLevel;
        baseHealth.OnHealthChange += RefreshHealth;
    }
    private void RefreshXp()
    {
        XpBar.maxValue = playerLevel.maxXp;
        XpBar.value = playerLevel.xp;
        XpText.text = playerLevel.xp.ToString();
        MaxXpText.text = playerLevel.maxXp.ToString();
    }

    private void RefreshLevel()
    {
        levelText.text = playerLevel.level.ToString();
    }
    
    private void RefreshHealth()
    {
        HealthSlider.value = baseHealth.CurrenthHealth;
        HealthSlider.maxValue = baseHealth.MaxHealth;
    }
}
