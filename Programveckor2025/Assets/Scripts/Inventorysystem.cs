using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
[System.Serializable]
public class Inventorysystem 
{
    [SerializeField] private List<InventorySlots> inventorySlots;

    public List<InventorySlots> InventorySlots => inventorySlots;

    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlots> OnInventorySlotChanged;

    public Inventorysystem(int size)
    {
        inventorySlots = new List<InventorySlots>(size);

     for(int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlots());

        }
   
    
    }


    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {
        if(ContainsItem(itemToAdd, out List<InventorySlots> invSlot))
        {
            foreach(var slot in invSlot)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
           

        }
        if(HasFreeSlot(out InventorySlots freeslot))
        {
            freeslot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeslot);
            return true;
        }
        return false;
    }


    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlots> invSlot)
    {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();
        Debug.Log(invSlot.Count);
        return invSlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlots freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;

    }
    
}
