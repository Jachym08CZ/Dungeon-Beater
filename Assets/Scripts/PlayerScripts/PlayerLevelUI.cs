using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUI : MonoBehaviour
{
    [Header("Xp")]

    public TMP_Text maxXpText;
    public TMP_Text xpText;
    public Slider xpBar;

    [Header("Level")]
    public TMP_Text levelText;
    [SerializeField] private PlayerLevel playerLevel;

    private void Start()
    {
        playerLevel.OnXpChange += refreshXp;
        playerLevel.OnLeveLUp += refreshLevel;
    }
    private void refreshXp()
    {
        xpBar.maxValue = playerLevel.maxXp;
        xpBar.value = playerLevel.xp;
        xpText.text = playerLevel.xp.ToString();
        maxXpText.text = playerLevel.maxXp.ToString();
    }

    private void refreshLevel()
    {
        levelText.text = playerLevel.level.ToString();
    }
}
