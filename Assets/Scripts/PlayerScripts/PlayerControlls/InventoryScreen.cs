using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryScreen : MonoBehaviour
{
    [SerializeField] SimplifiedFPSController _playercontroller;
    InputAction _openInventory;
    [SerializeField] GameObject _inventory;

    private void Awake()
    {
        _openInventory = InputSystem.actions.FindAction("OpenInventory");
    }

    private void Start()
    {
        CloseInventory();
    }
    private void Update()
    {
        if (_openInventory.WasPressedThisFrame())
        {
            if (_inventory.activeSelf == true)
            {
                CloseInventory();
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

    void CloseInventory()
    {
        _playercontroller.enabled = true;
        _inventory.SetActive(false);
    }
}
