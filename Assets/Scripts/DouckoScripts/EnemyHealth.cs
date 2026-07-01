using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : BaseHealthScript
{
    public override void UpdateHealthBar()
    {
        HealthBar.value = CurrenthHealth / MaxHealth;
        HealthBar.gameObject.transform.parent.rotation = Camera.main.transform.rotation;
        
        if (CurrenthHealth <= 0)
        {
            OnDeath();
        }
    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
    }
}
