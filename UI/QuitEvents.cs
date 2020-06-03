using Bytes.Controllers;
using UnityEngine;
using Bytes.Input;

public class QuitEvents : MonoBehaviour
{
    RoomController roomController;

    void Start()
    {
        roomController = FindObjectOfType<RoomController>();
    }

    public void OnQuitToMainMenu()
    {
        KeyboardPauseCommand.isPaused = false;
        Cursor.lockState = CursorLockMode.None;

        if (roomController)
            roomController.OnQuitToMainMenu();
    }

    public void OnQuit()
    {
        KeyboardPauseCommand.isPaused = false;

        if (roomController)
            roomController.OnQuit();
    }

    public void OnResume()
    {
        KeyboardPauseCommand.isPaused = false;
    }
}
