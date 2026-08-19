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

    [Header("Stamina")]
    public Slider StaminaSlider;

    [Header("Stamina")]
    public Slider ManaSlider;

    [Header("Coins")]
    public TMP_Text CoinsText;

    [SerializeField] private PlayerLevel playerLevel;
    [SerializeField] private BaseHealthScript baseHealth;
    [SerializeField] private PlayerStats playerstats;

    private void Start()
    {
        playerLevel.OnXpChange += RefreshXp;
        playerLevel.OnLeveLUp += RefreshLevel;
        baseHealth.OnHealthChange += RefreshHealth;
        playerstats.OnStaminaChanged += RefreshStamina;
        playerstats.OnManaChanged += RefreshMana;
        playerstats.OnCoinsChanged += RefreshCoins;

        RefreshXp();
        RefreshLevel();
        RefreshStamina();
        RefreshMana();
        RefreshCoins();
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
    
    private void RefreshStamina()
    {
        StaminaSlider.value = playerstats.stamina;
        StaminaSlider.maxValue = playerstats.maxStamina;
    }
    private void RefreshMana()
    {
        ManaSlider.value = playerstats.Mana;
        ManaSlider.maxValue = playerstats.maxMana;
    }

    private void RefreshCoins()
    {
        CoinsText.text = "Coins: " + playerstats.Coins;
    }
}
