using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new();

    public event Action OnInventoryChange;

    public IReadOnlyList<Item> Items
    {
        get { return Items; }
    }

    //Pridej Item

    public void AddItem(Item item)
    {
        _items.Add(item);
        OnInventoryChange?.Invoke();
    }
    //Odstran Item
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        OnInventoryChange?.Invoke();
    }
}
