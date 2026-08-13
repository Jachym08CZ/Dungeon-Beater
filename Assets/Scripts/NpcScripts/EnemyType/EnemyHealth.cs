using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : BaseHealthScript
{
    public PlayerRewardSystem playerReward;
    private void Awake()
    {
        playerReward = GetComponent<PlayerRewardSystem>();
    }

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
        playerReward.RewardPlayer();
        Destroy(gameObject);
    }
}
