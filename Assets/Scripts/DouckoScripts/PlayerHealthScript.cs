using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthScript  : BaseHealthScript
{
    private Rigidbody rb;

    private Coroutine deathCor;
    public override void Start()
    {
        base.Start();

    }

    public override void Update()
    {
        base.Update();
    }
    public override void TakeDamage(int dmg)
    {
        base.RemoveHealth(dmg);
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
