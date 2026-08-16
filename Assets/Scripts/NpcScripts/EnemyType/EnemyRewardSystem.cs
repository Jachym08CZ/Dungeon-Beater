using UnityEngine;

public class EnemyRewardSystem : MonoBehaviour
{
    [SerializeField] private float _xpReward;
    [SerializeField] private int _coinReward;

    PlayerStats _playerstats;
    PlayerLevel _playerLevel;
     private BaseHealthScript _health;
    private void Awake()
    {
        var Player = GameObject.FindWithTag("Player");
        _playerLevel = Player.GetComponent<PlayerLevel>();
        _playerstats = Player.GetComponent<PlayerStats>();
        _health = GetComponent<BaseHealthScript>();
    }
    private void OnEnable()
    {
        _health.DeathAction += RewardPlayer;
    }

    private void OnDisable()
    {
        _health.DeathAction -= RewardPlayer;
    }
    public void RewardPlayer()
    {
        _playerstats.ChangeCoins(_coinReward);
        _playerLevel.gainXp(_xpReward);
    }
}
