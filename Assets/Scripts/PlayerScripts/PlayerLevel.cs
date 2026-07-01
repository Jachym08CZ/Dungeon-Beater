using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    [Header("Xp")]
    public float xp;
    private float maxXp = 100f;
    private float secretXp;

    public TextMeshProUGUI maxXpText;
    public TextMeshProUGUI xpText;
    public Slider xpBar;

    [Header("Level")]
    public int level = 1;
    public TextMeshProUGUI levelText;
    private void Start()
    {
        refreshLevelUi();
    }
    private void refreshLevelUi()
    {
        xpBar.maxValue = maxXp;
        xpBar.value = xp;
        maxXpText.text = maxXp.ToSafeString();
        xpText.text = "xp " + xp.ToSafeString();

        levelText.text = level.ToSafeString();
    }
    private void LevelUp()
    {
        level++;
        levelText.text = level.ToSafeString();
        maxXp *= 1.15f;
        xp = 0;
        xp = secretXp;
        secretXp = 0;
        refreshLevelUi();
    }
    public void gainXp(float recievedXp)
    {
        xp += recievedXp;
        if (xp == maxXp)
        {
            LevelUp();
        }
        else if (xp > maxXp)
        {
            secretXp = xp - maxXp;
            LevelUp();
        }
        refreshLevelUi();
    }

}
