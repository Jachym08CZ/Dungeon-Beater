using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Equipment _equipment;

    [SerializeField] private Inventory _inventory;

    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private PlayerHealthScript _playerhealth;

    [SerializeField] private GameObject DefaultPrefab;

    private Container _openedContainer;

    public event Action<Container> OnContainerOpened;
    public event Action OnContainerClosed;

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
    // DropItem

    public void DropItem(Item item)
    {
        _inventory.RemoveItem(item);
        GameObject itemPrefab = item.WorldPrefab;
        if (itemPrefab == null)
        {
            itemPrefab = DefaultPrefab;
        }
       GameObject pickedItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        pickedItem.GetComponent<ItemPickUp>().SetItem(item);
    }

    // Open Container
    public void OpenContainer(Container container)
    {
        _openedContainer = container;
        OnContainerOpened?.Invoke(container);
    }
    // Close Container
    public void CloseContainer()
    {
        if (_openedContainer != null)
        {
            _openedContainer = null;
            OnContainerClosed?.Invoke();
        }
    }
    // Take Item From Container
    public void TakeFromContainer(Item item)
    {
        MoveItem(item, _openedContainer.Inventory, _inventory);
    }

    // Move Item 
    private void MoveItem(Item item, Inventory From, Inventory To)
    {
        From.RemoveItem(item);
        To.AddItem(item);
    }
}
