using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    //add to item
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;

    private CircleCollider2D Mycollider;

    private void Awake()
    {
        Mycollider = GetComponent<CircleCollider2D>();  // Change to CircleCollider2D
        Mycollider.isTrigger = true;
        Mycollider.radius = PickUpRadius;  // Set radius of CircleCollider2D
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();
        if (!inventory) return;

        if (inventory.Inventorysystem.AddToInventory(ItemData, 1))
        {
            Destroy(this. gameObject);
        }
    }
}
