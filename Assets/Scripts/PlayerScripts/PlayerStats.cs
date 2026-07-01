using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float health = 100f;
    public float maxHealth = 100f;
    public Slider healthBar;

    [Header("Stamina")]

    public float stamina = 100f;
    public float maxStamina = 100f;

    [Header("Magic")]

    public float mana = 10f;
    public float maxMana = 10f;
    public Slider manaBar;

    [Header("Currency")]
    public int coins = 0;

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        manaBar.maxValue = maxMana;
    }

    private void Update()
    {
        healthBar.value = health;
        manaBar.value = mana;
    }
}
