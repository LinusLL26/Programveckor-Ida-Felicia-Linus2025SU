using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    //place on player object to work
    [SerializeField] private int inventorySize;
    [SerializeField] protected Inventorysystem inventorySystem;

    public Inventorysystem Inventorysystem => inventorySystem;

    public static UnityAction<Inventorysystem> OnDynamicInventoryDisplayRequested;

    private void Awake()
    {
        inventorySystem = new Inventorysystem(inventorySize);
    }
}
