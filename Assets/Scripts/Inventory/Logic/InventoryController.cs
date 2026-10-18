using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Equipment _equipment;

    [SerializeField] private Inventory _inventory;

    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private PlayerHealthScript _playerhealth;
    //useItem
    public void UseItem(Item item)
    {
        if (item.kind == ItemKind.Equippable)
        {
            EquipItem(item);
        }
        if(item.kind == ItemKind.Consumable)
        {
            ConsumeItem(item);
        }
 
    }
    //EquipItem
    private void EquipItem(Item item)
    {
        //vytahnout
        _inventory.RemoveItem(item);
        //equip
        Item previousItem = _equipment.Equip(item);
        //vratit
        if (previousItem != null)
        {
            _inventory.AddItem(previousItem);
        }
    }
    //UnEquipSlot
    public void UnEquipSlot(EquipSlot slot)
    {
        Item removed = _equipment.UnEquip(slot);
        
        if (removed != null)
        {
            _inventory.AddItem(removed);
        }
    }

    //ConsumeItem
    
    private void ConsumeItem(Item item)
    {
        if (item.ManaRestore > 0.0f)
        {
            _playerStats.AddMana(item.ManaRestore);
        }
        if (item.HealthRestore > 0.0f)
        {
            _playerhealth.ChangeHealth(item.HealthRestore);
        }
        _inventory.RemoveItem(item);
    }
    //
}
