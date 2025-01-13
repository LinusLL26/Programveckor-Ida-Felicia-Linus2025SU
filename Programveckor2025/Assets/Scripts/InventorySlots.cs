using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventorySlots
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlots(InventoryItemData source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlots()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlot(InventoryItemData data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }

public bool RoomLeftInStack(int amountToadd, out int amountRemaning)
    {
        amountRemaning = ItemData.MaxStackSize - stackSize;

        return RoomLeftInStack(amountToadd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.MaxStackSize) return true;
        else return false;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveromStack(int amount)
    {
        stackSize -= amount;
    }
}
