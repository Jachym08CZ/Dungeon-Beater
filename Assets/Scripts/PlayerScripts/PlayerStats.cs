using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    [Header("Stamina")]

    public float stamina = 100f;
    public float maxStamina = 100f;

    [Header("Magic")]

    public float mana = 10f;
    public float maxMana = 10f;

    [Header("Currency")]
    public int coins = 0;

    private void Start()
    {
    }

    private void Update()
    {

    }
}
