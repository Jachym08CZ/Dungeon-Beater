using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUi : MonoBehaviour
{
    [SerializeField] private Image _iconImage;

    [SerializeField] private TMP_Text _nametext;

    private Item item;

    private InventoryUi owner;

    public void Setup(Item item, InventoryUi owner)
    {
        this.item = item;
        this.owner = owner;
        _iconImage.sprite = item.Icon;
        _nametext.text = item.name;
    }

    public void HandleClick()
    {
        owner.HandleSlotClicked(item);
    }

    public void HandleDropClick()
    {
        owner.HandleDropClicked(item);
    }    
}
