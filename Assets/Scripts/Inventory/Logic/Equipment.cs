using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    Dictionary<EquipSlot, Item> equipped = new();

    public event Action OnEquipmentChange;

    //GetEquipped
    public Item GetEquipped(EquipSlot slot)
    {
        if (equipped.ContainsKey(slot))
        {
            return equipped[slot];
        }
        else
        {
            return null;
        }
    }
    //Pridat
    public Item Equip(Item item)
    {
        var itemPrevious = GetEquipped(item.slot);
        equipped[item.slot] = item;
        OnEquipmentChange?.Invoke();
        return itemPrevious;
    }
    //Odebrat
    public Item UnEquip(EquipSlot slot)
    {
        var RemovedItem = GetEquipped(slot);
        if (RemovedItem == null) return null;
        equipped.Remove(slot);
        OnEquipmentChange?.Invoke();
        return RemovedItem;
    }

    public float TotalDamageBonus => equipped.Values.Sum(i => i.DamageBonus);
    public float TotalManaBonus => equipped.Values.Sum(i => i.ManaRestore);
    public float TotalHealthBonus => equipped.Values.Sum(i => i.HealthRestore);

}
