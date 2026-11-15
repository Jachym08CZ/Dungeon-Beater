using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Container : MonoBehaviour, IInteractable
{
    private Inventory _inventory;
    [SerializeField] private string _name;
    public Inventory Inventory { get { return _inventory; } }
    public string Name { get { return _name; } }

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }
    public string GetPrompt()
    {
        return $"Press E to Open {Name}";
    }

    public void Interact(GameObject player)
    {
        player.GetComponent<InventoryController>().OpenContainer(this);
    }

}
