using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private Item _item;
    
    public string GetPrompt()
    {
        return "PickUp E";
    }

    public void Interact(GameObject player)
    {
        Inventory _inventory = player.GetComponent<Inventory>();
        if (_inventory == null) return;
        _inventory.AddItem(_item);
        Destroy(this.gameObject);
    }
}
