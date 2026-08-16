using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : BaseHealthScript
{

    public override void Start()
    {
        base.Start();
    }
    public override void ChangeHealth(int dmg)
    {
        base.ChangeHealth(dmg);
    }

    public override void OnDeath()
    {
        base.OnDeath();
        Destroy(gameObject);
    }
}
