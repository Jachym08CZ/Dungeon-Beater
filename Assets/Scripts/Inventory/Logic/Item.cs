using UnityEngine;

public enum ItemKind
{
    Equippable,
    Consumable,
    Junk
}
public enum EquipSlot
{
    Helmet,
    Armor,
    Weapon
}

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [Header("Basic Informations")]
    
    public string Name;
    public Sprite Icon;
    public int price;
    public ItemKind kind;

    [Header("For Equippable ")]

    public EquipSlot slot;
    public float DamageBonus;
    public float DamageReduction;
    public float ManaRegen;

    [Header("For Consumable ")]
    public int HealthRestore;
    public int ManaRestore;
}
