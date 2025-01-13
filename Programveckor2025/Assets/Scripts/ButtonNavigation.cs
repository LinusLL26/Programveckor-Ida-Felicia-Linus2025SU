using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonNavigation : MonoBehaviour
{
    public Button[] buttons;  // Reference to the buttons in the current menu
    public GameObject mainMenuPanel;  // Reference to the Main Menu (Pause Menu)
    public GameObject inventoryPanel;  // Reference to the Inventory Panel

    private int currentIndex = 0;
    private bool isPaused = false; // Tracks if the game is paused

    void Start()
    {
        // Ensure both panels are hidden at the start
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        // Setup initial button selection
        if (buttons.Length > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);
            buttons[currentIndex].Select();  // Select the first button
        }
    }

    void Update()
    {
        // Pause menu toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryPanel.activeSelf)
            {
                SwitchToMainMenu(); // Exit inventory and return to the pause menu
            }
            else
            {
                TogglePauseMenu(); // Toggle pause menu visibility
            }
        }

        // Button navigation only when a menu is active
        if (isPaused && mainMenuPanel.activeSelf)
        {
            HandleButtonNavigation();
        }
    }

    private void HandleButtonNavigation()
    {
        // Navigate between buttons with Up/Down arrows
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex = (currentIndex > 0) ? currentIndex - 1 : buttons.Length - 1;
            SelectButton(currentIndex);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex = (currentIndex < buttons.Length - 1) ? currentIndex + 1 : 0;
            SelectButton(currentIndex);
        }

        // Trigger the selected button's action with Enter/Return
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PressButton(currentIndex);
        }
    }

    private void SelectButton(int index)
    {
        if (buttons.Length > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
            buttons[index].Select();
        }
    }

    private void PressButton(int index)
    {
        if (buttons[index] != null)
        {
            buttons[index].onClick.Invoke(); // Trigger the button's onClick event
        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            mainMenuPanel.SetActive(true); // Show the pause menu
            inventoryPanel.SetActive(false); // Ensure the inventory is hidden

            // Initialize button navigation for the pause menu
            buttons = mainMenuPanel.GetComponentsInChildren<Button>();
            currentIndex = 0; // Start with the first button
            SelectButton(currentIndex);
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            mainMenuPanel.SetActive(false); // Hide the pause menu
            inventoryPanel.SetActive(false); // Ensure the inventory is hidden
        }
    }

    public void SwitchToInventory()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(true);

        // Initialize button navigation for the inventory menu
        buttons = inventoryPanel.GetComponentsInChildren<Button>();
        currentIndex = 0; // Start with the first button
        SelectButton(currentIndex);
    }

    public void SwitchToMainMenu()
    {
        inventoryPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

        // Initialize button navigation for the main menu
        buttons = mainMenuPanel.GetComponentsInChildren<Button>();
        currentIndex = 0; // Start with the first button
        SelectButton(currentIndex);
    }

    public void QuitGame()
    {
        // Implement quit functionality
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
