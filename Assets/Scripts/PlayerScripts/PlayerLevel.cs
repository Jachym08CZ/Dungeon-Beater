using System;
using UnityEngine;


public class PlayerLevel : MonoBehaviour
{
    [Header("Xp")]
    public float xp;
    public float maxXp = 100f;
    private float spareXp;

   [Header("Level")]
    public int level = 1;

    public event Action OnLeveLUp;
    public event Action OnXpChange;
    private void Start()
    {
    }
   
    private void LevelUp()
    {
        level++;
        maxXp *= 1.15f;
        xp = 0;
        xp = spareXp;
        spareXp = 0;
        OnLeveLUp.Invoke();
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
            spareXp = xp - maxXp;
            LevelUp();
        }
        OnXpChange.Invoke();
    }

}
