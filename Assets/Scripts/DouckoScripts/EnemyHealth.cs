using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : BaseHealthScript
{


    public override void ChangeHealth(int dmg)
    {
        base.ChangeHealth(dmg);
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
    }
}
