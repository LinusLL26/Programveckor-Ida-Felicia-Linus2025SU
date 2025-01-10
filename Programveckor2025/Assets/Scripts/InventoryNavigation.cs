using UnityEngine;

public class InventoryButtonScript : MonoBehaviour
{
    public GameObject mainUI;  
    public GameObject inventoryUI;  

    public void ShowInventory()
    {
        
        mainUI.SetActive(false);
        inventoryUI.SetActive(true);
    }

    
    public void ShowMainUI()
    {
        // Show the Main UI and hide the Inventory UI
        mainUI.SetActive(true);
        inventoryUI.SetActive(false);
    }
}
