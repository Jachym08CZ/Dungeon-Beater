using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryScreen : MonoBehaviour
{
    [SerializeField] SimplifiedFPSController _playercontroller;
    InputAction _openInventory;
    //InputAction _AltClose;
    [SerializeField] GameObject _inventory;
    [SerializeField] InventoryController _inventoryController;

    [SerializeField] GameObject _equipmentInventory;
    [SerializeField] GameObject _containerInventory;

    [SerializeField] InventoryUi _inventoryUi;
    [SerializeField] TMP_Text _containerName;

    private void Awake()
    {
        _openInventory = InputSystem.actions.FindAction("OpenInventory");
        //_AltClose = InputSystem.actions.FindAction("Interact"); -- musí se vypnout raycast, zavøeto a pak to hned otevøe
    }

    private void Start()
    {
        _inventoryController.OnContainerOpened += HandleContainerOpened;
        _inventoryController.OnContainerClosed += HandleContainerClosed;
        CloseAll();
    }
    private void Update()
    {
        if (_openInventory.WasPressedThisFrame())
        {
            if (_inventory.activeSelf || _containerInventory.activeSelf)
            {
                CloseAll();
            }
            else
            {
                OpenInventory();
            }
        }
    }
    void OpenInventory()
    {
        _playercontroller.enabled = false;
        _inventory.SetActive(true);
    }

    private void HandleContainerOpened(Container container)
    {
        _inventory.SetActive(false);
        _containerInventory.SetActive(false);

        _inventoryUi.SetInventory(container.Inventory);
        _containerName.text = container.Name;

        _containerInventory.SetActive(true);
        _playercontroller.enabled = false;
    }

    private void HandleContainerClosed()
    {
        _containerInventory.SetActive(false);
        
    }
    private void CloseAll()
    {
        _inventoryController.CloseContainer();
        _inventory.SetActive(false);
        HandleContainerClosed();
        _playercontroller.enabled = true;
    }
    private void OnDestroy()
    {
        _inventoryController.OnContainerOpened -= HandleContainerOpened;
        _inventoryController.OnContainerClosed -= HandleContainerClosed;
    }
}
