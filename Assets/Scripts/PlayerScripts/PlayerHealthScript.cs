using System;
using System.Collections;
using UnityEngine;


public class PlayerHealthScript  : BaseHealthScript
{

    private Coroutine deathCor;
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
        deathCor = StartCoroutine(DeathCorutine());
    }

    private IEnumerator DeathCorutine()
    {
        yield return new WaitForSeconds(3);

        base.OnDeath();

        deathCor = null;
    }
}
