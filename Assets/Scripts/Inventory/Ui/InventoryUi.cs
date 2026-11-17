using System;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    [SerializeField] private GameObject _rowPrefab;
    [SerializeField] private Transform _listParent;
    [SerializeField] private InventoryController _inventoryController;

    private Inventory _currentInventory;

    [SerializeField] private bool IsContainterPanel;

    private void OnEnable()
    {
        if (!IsContainterPanel)
        {
            _currentInventory = _inventoryController.GetComponent<Inventory>();
        }
        if (_currentInventory == null) return;
        _currentInventory.OnInventoryChange += RefreshList;
        RefreshList();
    }
    private void OnDisable()
    {
        if(_currentInventory != null)
        {
            _currentInventory.OnInventoryChange -= RefreshList;
        }
    }
    //ShowInvenotory
    public void ShowInventory(Inventory target)
    {
        if(_currentInventory != null)
        {
            _currentInventory.OnInventoryChange -= RefreshList;
        }

        _currentInventory = target;
        _currentInventory.OnInventoryChange += RefreshList;
        RefreshList();
    }

    //RefreshList
    private void RefreshList()
    {
        foreach(Transform child in _listParent)
        {
            Destroy(child.gameObject);
        }
        foreach(Item item in _currentInventory.Items)
        {
            GameObject row = Instantiate(_rowPrefab, _listParent);

            row.GetComponent<InventorySlotUi>().Setup(item, this);
        }
    }

    public void HandleSlotClicked(Item item)
    {
        if (IsContainterPanel)
        {
            _inventoryController.TakeFromContainer(item);
        }
        else
        {
            _inventoryController.UseItem(item);
        }
    }
    
    public void HandleDropClicked(Item item)
    {
        _inventoryController.DropItem(item);
    }

    public void SetInventory(Inventory targetInventory)
    {
        _currentInventory = targetInventory;
    }
}
