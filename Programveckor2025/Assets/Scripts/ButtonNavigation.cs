using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonNavigation : MonoBehaviour
{
    public Button[] buttons;  // Reference to the buttons in the current menu
    public Image[] buttonBackgrounds; // Reference to the background images
    private int currentIndex = 0;

    public GameObject mainMenuPanel;  // Reference to the Main Menu (Pause Menu)
    public GameObject inventoryPanel;  // Reference to the Inventory Panel

    void Start()
    {
        if (buttons.Length > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);
            buttons[currentIndex].Select();  // Make sure the first button is selected
            ShowBackground(currentIndex);  // Show the background behind the selected button
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            NavigateButtons();
        }


        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PressButton(currentIndex);  // Trigger the selected button's onClick
        }
    }

    private void NavigateButtons()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex++;
        }

        // Wrap around the button index to keep it within bounds
        if (currentIndex < 0) currentIndex = buttons.Length - 1;
        if (currentIndex >= buttons.Length) currentIndex = 0;

        ShowBackground(currentIndex);

        EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);
        buttons[currentIndex].Select(); // Ensure the button is selected
    }

    // Function to show the background for the currently selected button
    private void ShowBackground(int index)
    {
        // Hide all backgrounds first
        foreach (Image background in buttonBackgrounds)
        {
            background.color = new Color(0, 0, 0, 0); // Make the background invisible
        }

        // Make the selected button's background visible
        buttonBackgrounds[index].color = new Color(0, 0, 0, 1f);
    }

    // Function to simulate pressing the selected button
    private void PressButton(int index)
    {
        if (buttons[index] != null)
        {
            buttons[index].onClick.Invoke(); // Trigger the selected button's OnClick() event
        }
    }

    // Function to toggle between Main Menu (Pause Menu) and Inventory
    public void SwitchToMainMenu()
    {
        // Hide the Inventory panel and show the Pause Menu (Main Menu) panel
        inventoryPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

        // You can also reset button navigation if needed
        currentIndex = 0;  // Set it to the first button in the main menu
        buttons = mainMenuPanel.GetComponentsInChildren<Button>();  // Update the buttons array
        buttonBackgrounds = mainMenuPanel.GetComponentsInChildren<Image>();  // Update background images
    }

    // Function to switch to the Inventory Menu (can be hooked to the Inventory Button in the Pause Menu)
    public void SwitchToInventory()
    {
        // Hide the Pause Menu (Main Menu) panel and show the Inventory panel
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(true);

        // You can also reset button navigation for the inventory menu
        currentIndex = 0;  // Set it to the first button in the inventory menu
        buttons = inventoryPanel.GetComponentsInChildren<Button>();  // Update the buttons array
        buttonBackgrounds = inventoryPanel.GetComponentsInChildren<Image>();  // Update background images
    }
}