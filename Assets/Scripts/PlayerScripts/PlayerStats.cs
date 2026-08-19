using System;
using System.Collections;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    [Header("Stamina")]

    public float stamina = 100f;
    public float maxStamina = 100f;
    public bool StaminaIsdrained;
    public event Action OnStaminaChanged;
    private Coroutine _regenStaminaCoroutine;

    [Header("Magic")]

    public float Mana = 100f;
    public float maxMana = 100f;
    public bool ManaIsRegenerating;
    public event Action OnManaChanged;

    [Header("Currency")]
    public int Coins = 0;
    public event Action OnCoinsChanged;
    private void Start()
    {
        StaminaIsdrained = false;
        ManaIsRegenerating = false;
    }

    private void Update()
    {
        if (StaminaIsdrained == false)
        {
            AddStamina(5f * Time.deltaTime);
        }
        if (ManaIsRegenerating == true)
        {
            AddMana(25f * Time.deltaTime);
        }    
    }

    public bool DrainStamina(float ammount)
    {
        if (stamina <= ammount) return false; 

        stamina -= ammount;
        OnStaminaChanged?.Invoke();
        if (_regenStaminaCoroutine != null)
        {
            StopCoroutine(_regenStaminaCoroutine);
        }
        _regenStaminaCoroutine = StartCoroutine(replenishStamina(3));
        StaminaIsdrained = true;
        return true;
    }
    public void AddStamina(float ammount)
    {
        if (stamina + ammount >= maxStamina) return;
        stamina += ammount;
        OnStaminaChanged?.Invoke();
    }

    public IEnumerator replenishStamina(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StaminaIsdrained = false;
        _regenStaminaCoroutine = null;
    }

    public bool DrainMana(float ammount)
    {
        if (Mana <= ammount) return false;

        Mana -= ammount;
        OnManaChanged?.Invoke();
        return true;
    }
    public void AddMana(float ammount)
    {
        if (Mana >= maxMana) return;
        Mana += ammount;
        OnManaChanged?.Invoke();
    }

    public void ManaRegenState(bool state)
    {
        Debug.Log(state);
        ManaIsRegenerating = state;
    }
    public void ChangeCoins(int ammount)
    {
        Coins += ammount;
        OnCoinsChanged?.Invoke();

    }
}
