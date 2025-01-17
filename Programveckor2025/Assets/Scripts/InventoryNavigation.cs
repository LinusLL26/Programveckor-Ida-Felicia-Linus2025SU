using UnityEngine;

public class InventoryButtonScript : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject inventoryUI;


    private InventoryHolder playerInventoryHolder; 

    private void Start()
    {
       
        
    }

    public void ShowInventory()
    {
        mainUI.SetActive(false);
        inventoryUI.SetActive(true);
    }

    public void ShowMainUI()
    {
        mainUI.SetActive(true);
        inventoryUI.SetActive(false);
    }
}
