using System;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    [Header("Stamina")]

    public float stamina = 100f;
    public float maxStamina = 100f;
    public bool IsDrained = false;

    public event Action OnStaminaChanged;

    [Header("Magic")]

    public float Mana = 10f;
    public float maxMana = 10f;
    public event Action OnManaChanged;

    [Header("Currency")]
    public int Coins = 0;
    public event Action OnCoinsChanged;
    private void Start()
    {
    }

    private void Update()
    {
        if (IsDrained == false)
        {
            AddStamina(0.25f);
        }
    }

    public void DrainStamina(float ammount)
    {
        if (stamina <= ammount) return;
        stamina -= ammount;
        OnStaminaChanged.Invoke();
    }
    public void AddStamina(float ammount)
    {
        if (stamina >= maxStamina) return;
        stamina += ammount;
        OnStaminaChanged.Invoke();
    }

    public void DrainMana(float ammount)
    {
        if (Mana <= ammount) return;
        Mana -= ammount;
        OnManaChanged.Invoke();
    }
    public void AddMana(float ammount)
    {
        if (Mana >= maxMana) return;
        Mana += ammount;
        OnManaChanged.Invoke();
    }
    public void ChangeCoins(int ammount)
    {
        Coins += ammount;
        OnCoinsChanged.Invoke();

    }
}
