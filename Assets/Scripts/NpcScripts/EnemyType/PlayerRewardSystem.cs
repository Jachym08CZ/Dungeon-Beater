using UnityEngine;

public class PlayerRewardSystem : MonoBehaviour
{

    PlayerStats _playerstats;
    PlayerLevel _playerLevel;
    public GameObject player;
    private void Awake()
    {
        _playerLevel = player.GetComponent<PlayerLevel>();
        _playerstats = player.GetComponent<PlayerStats>();
    }
    public void RewardPlayer()
    {
        _playerstats.ChangeCoins(10);
        _playerLevel.gainXp(12);
    }
}
