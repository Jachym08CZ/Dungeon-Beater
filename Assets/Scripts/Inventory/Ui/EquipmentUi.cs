using UnityEngine;
using UnityEngine.UI;

public class EquipmentUi : MonoBehaviour
{
    [SerializeField] private Equipment _equipment;
    [SerializeField] private InventoryController _inventoryController;

    [Header("Ikony slotù")]
    [SerializeField] private Image _helmetIcon;
    [SerializeField] private Image _armorIcon;
    [SerializeField] private Image _weaponIcon;

    [SerializeField] private Sprite _emptySlotSprite;

    private void Start()
    {
        _equipment.OnEquipmentChange += RefreshSlots;
        RefreshSlots();
    }

    private void OnDestroy()
    {
        _equipment.OnEquipmentChange -= RefreshSlots;
    }
    private void RefreshSlots()
    {
        RefreshOneSlot(_helmetIcon, EquipSlot.Helmet);
        RefreshOneSlot(_armorIcon, EquipSlot.Armor);
        RefreshOneSlot(_weaponIcon, EquipSlot.Weapon);
    }
    private void RefreshOneSlot(Image icon, EquipSlot slot)
    {
        Item item = _equipment.GetEquipped(slot);
        if (item != null)
        {
            icon.sprite = item.Icon;
        }
        else
        {
            icon.sprite = _emptySlotSprite;
        }
    }


    public void UnEquipHelmet() { _inventoryController.UnEquipSlot(EquipSlot.Helmet); }
    public void UnEquipArmor() { _inventoryController.UnEquipSlot(EquipSlot.Armor); }
    public void UnEquipWeapon() { _inventoryController.UnEquipSlot(EquipSlot.Weapon); }
}
