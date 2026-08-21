using System;
using UnityEngine;
public class BaseHealthScript : MonoBehaviour, IDamageable
{
    public float CurrenthHealth;
    public float MaxHealth = 100;

    public event Action DeathAction;
    public event Action OnHealthChange;
    public virtual void Start()
    {
        CurrenthHealth = MaxHealth;
        ChangeHealth(0);

        //DeathAction += GameManager.Instance.Restart;
    }

    public virtual void Update()
    {
        if (CurrenthHealth <= 0)
        {
            OnDeath();
        }
    }
    public virtual void OnDeath()
    {
        DeathAction.Invoke();
        Debug.Log("Death");
    }

    public virtual void ChangeHealth(int dmg)
    {
        CurrenthHealth += dmg;
        OnHealthChange?.Invoke();
    }
}
