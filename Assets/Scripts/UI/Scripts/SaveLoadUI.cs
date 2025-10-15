using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    // Кнопки UI должны вызывать эти публичные методы через OnClick()

    public void OnNewGameButton()
    {
        GameSaveManager.Instance.NewGame();
        Debug.Log("New game created.");
    }

    public void OnSaveGameButton()
    {
        GameSaveManager.Instance.SaveGame();
        Debug.Log("Game saved.");
    }

    public void OnLoadGameButton()
    {
        GameSaveManager.Instance.LoadGame();
        Debug.Log("Game loaded.");
    }

    public void OnDeleteSaveButton()
    {
        GameSaveManager.Instance.DeleteSave();
        Debug.Log("Save deleted (and new default created).");
    }

    public void OnSaveSettingsButton()
    {
        AccountSettingsManager.Instance.SaveSettings();
        Debug.Log("Settings saved.");
    }

    public void OnLoadSettingsButton()
    {
        AccountSettingsManager.Instance.LoadSettings();
        Debug.Log("Settings loaded.");
    }
}