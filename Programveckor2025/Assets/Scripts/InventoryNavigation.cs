using UnityEngine;

public class InventoryButtonScript : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject inventoryUI;
    public StaticInventoryDisplay inventoryDisplay;

    private InventoryHolder playerInventoryHolder; // Ensure this is assigned to the Player's InventoryHolder

    private void Start()
    {
        // Locate the Player and its InventoryHolder if not manually assigned
        if (playerInventoryHolder == null)
        {
            var player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerInventoryHolder = player.GetComponent<InventoryHolder>();
            }
        }

        if (playerInventoryHolder != null && inventoryDisplay != null)
        {
            inventoryDisplay.AssignSlot(playerInventoryHolder.Inventorysystem);
        }
        else
        {
            Debug.LogError("Player Inventory or Inventory Display not properly assigned.");
        }
    }

    public void ShowInventory()
    {
        mainUI.SetActive(false);
        inventoryUI.SetActive(true);

        // Refresh inventory UI in case it was modified
        inventoryDisplay.AssignSlot(playerInventoryHolder.Inventorysystem);
    }

    public void ShowMainUI()
    {
        mainUI.SetActive(true);
        inventoryUI.SetActive(false);
    }
}
