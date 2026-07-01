using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
public class BaseHealthScript : MonoBehaviour, IDamageable
{
    public float CurrenthHealth;
    public float MaxHealth = 100;
    public Slider HealthBar;

    //public event Action DeathAction;

    public virtual void Start()
    {
        CurrenthHealth = MaxHealth;

        //DeathAction += GameManager.Instance.Restart;
    }
    public virtual void Update()
    {
        UpdateHealthBar();
    }
    public virtual void RemoveHealth(int dmg)
    {
        CurrenthHealth -= dmg;

    }

    public virtual void UpdateHealthBar()
    {
        HealthBar.value = CurrenthHealth / MaxHealth;
        if (CurrenthHealth <= 0)
        {
            OnDeath();
        }
    }

    public virtual void OnDeath()
    {
        //DeathAction.Invoke();
    }

    public virtual void TakeDamage(int dmg)
    {
        CurrenthHealth -= dmg;
    }
}
