using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryitem;
    protected Inventorysystem inventorySystem;
    protected Dictionary<InventorySlotsUI, InventorySlots> slotDictionary;
    public Inventorysystem InventorySystemn => inventorySystem;
    public Dictionary<InventorySlotsUI, InventorySlots> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }
    
        public abstract void AssignSlot(Inventorysystem invToDisplay);


    protected virtual void UpdateSlot(InventorySlots UpdatedSlot)
    {
        foreach(var slot in SlotDictionary)
        {
            if(slot.Value == UpdatedSlot)
            {
                slot.Key.UpdateUISlot(UpdatedSlot);
            }
        }
    }


    public void SlotClicked(InventorySlotsUI clickedSlot)
    {
        Debug.Log("Slot clicked");

    }
}
