using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonNavigation : MonoBehaviour
{
    public Button[] buttons;
    public GameObject mainMenuPanel;
    public GameObject inventoryPanel;

    private int currentIndex = 0;
    private bool isPaused = false; // Tracks if the game is paused

    void Start()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        // Pause menu toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("panel: " + inventoryPanel.activeSelf);
            if (inventoryPanel.activeSelf)
            {
                SwitchToMainMenu(); // Exit inventory and return to the pause menu
            }
            else
            {
                print("Toggle pause menu");
                TogglePauseMenu();
            }
        }

        if (isPaused && mainMenuPanel.activeSelf)
        {
            print("Inne i pause + main true");
            HandleButtonNavigation();
        }
    }

    private void HandleButtonNavigation()
    {
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

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PressButton(currentIndex);
        }
    }

    private void SelectButton(int index)
    {
        if (buttons.Length > 0 && index >= 0 && index < buttons.Length)
        {
            EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
            buttons[index].Select();
            Debug.Log("Selected button: " + buttons[index].name); // Debug log to confirm the button selection
        }
        else
        {
            Debug.LogWarning("Button index out of bounds: " + index);
        }
    }

    private void PressButton(int index)
    {
        // Ensure the buttons array is not null and index is within bounds
        if (buttons != null && buttons.Length > 0 && index >= 0 && index < buttons.Length)
        {
            Button button = buttons[index];

            // Check if the button is not null
            if (button != null)
            {
                if (button.onClick != null && button.onClick.GetPersistentEventCount() > 0)
                {
                    button.onClick.Invoke();
                    Debug.Log("Button " + index + " pressed: " + button.name);
                }
                else
                {
                    Debug.LogWarning("Button at index " + index + " has no onClick listeners assigned.");
                }
            }
            else
            {
                Debug.LogWarning("Button at index " + index + " is null.");
            }
        }
        else
        {
            Debug.LogWarning("Invalid button press attempt at index: " + index + ". Button array is null or index is out of bounds.");
        }
    }


    public void TogglePauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            mainMenuPanel.SetActive(true); // Show the pause menu
            inventoryPanel.SetActive(false);

            // Initialize button navigation for the pause menu
            buttons = mainMenuPanel.GetComponentsInChildren<Button>();
            currentIndex = 0; // Start with the first button
            SelectButton(currentIndex);
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            mainMenuPanel.SetActive(false); // Hide the pause menu
            inventoryPanel.SetActive(false);
        }
    }

    public void SwitchToInventory()
    {
        print("Inne i switch to inventory");
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(true);

        // Initialize button navigation for the inventory menu
        buttons = inventoryPanel.GetComponentsInChildren<Button>();
        currentIndex = 0; // Start with the first button
        SelectButton(currentIndex);
    }

    public void SwitchToMainMenu()
    {
        print("Inne i switch to main");
        inventoryPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

        // Initialize button navigation for the main menu
        buttons = mainMenuPanel.GetComponentsInChildren<Button>();
        currentIndex = 0; // Start with the first button
        SelectButton(currentIndex);
    }
}
