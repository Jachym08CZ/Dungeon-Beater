using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    [SerializeField] private GameObject _rowPrefab;
    [SerializeField] private Transform _listParent;
    [SerializeField] private InventoryController _inventoryController;

    private Inventory _currentInventory;

    private void Start()
    {
        ShowInventory(_inventoryController.GetComponent<Inventory>());
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

    
    private void OnDestroy()
    {
        if(_currentInventory != null)
        {
            _currentInventory.OnInventoryChange -= RefreshList;
        }
        
    }

    public void HandleSlotClicked(Item item)
    {
        _inventoryController.UseItem(item);
    }
    
    public void HandleDropClicked(Item item)
    {
        _currentInventory.RemoveItem(item);
    }
}
