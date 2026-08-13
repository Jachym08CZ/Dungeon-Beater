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
    public IEnumerator coroutine;

    [Header("Magic")]

    public float Mana = 10f;
    public float maxMana = 10f;
    public event Action OnManaChanged;

    [Header("Currency")]
    public int Coins = 0;
    public event Action OnCoinsChanged;
    private void Start()
    {
        StaminaIsdrained = false;
    }

    private void Update()
    {
        if (StaminaIsdrained == false)
        {
            AddStamina(0.5f);
        }

    }
    private void LateUpdate()
    {
        if (StaminaIsdrained == true)
        {
            StartCoroutine(replenishStamina(3));
        }


    }
    public bool DrainStamina(float ammount)
    {
        if (stamina <= ammount || stamina <= 0) return false; 

        stamina -= ammount;
        OnStaminaChanged.Invoke();
        StopAllCoroutines();
        StaminaIsdrained = true;
        return true;
    }
    public void AddStamina(float ammount)
    {
        if (stamina >= maxStamina) return;
        stamina += ammount;
        OnStaminaChanged.Invoke();
    }

    public IEnumerator replenishStamina(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StaminaIsdrained = false;
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
        //OnCoinsChanged.Invoke();

    }
}
