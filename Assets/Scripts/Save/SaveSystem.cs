using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    // --- Центральная точка хранения пути ---
    public static string SavesFolder = "Assets/Saves";

    private static string gameSavePath => Path.Combine(SavesFolder, "GameSave.json");
    private static string accountSettingsPath => Path.Combine(SavesFolder, "AccountSettings.json");

    // ---- GameSave ----
    public static void SaveGame(GameSave data)
    {
        try
        {
            if (!Directory.Exists(SavesFolder))
                Directory.CreateDirectory(SavesFolder);

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(gameSavePath, json);
            Debug.Log("[SaveSystem] Game saved to: " + gameSavePath);
        }
        catch (Exception e)
        {
            Debug.LogError("[SaveSystem] SaveGame failed: " + e.Message);
        }
    }

    public static GameSave LoadGame()
    {
        try
        {
            if (!File.Exists(gameSavePath))
            {
                Debug.Log("[SaveSystem] No game save found. Creating new default GameSave.");
                var defaultSave = new GameSave();
                SaveGame(defaultSave);
                return defaultSave;
            }

            string json = File.ReadAllText(gameSavePath);
            var save = JsonUtility.FromJson<GameSave>(json);
            Debug.Log("[SaveSystem] Game loaded from: " + gameSavePath);
            return save;
        }
        catch (Exception e)
        {
            Debug.LogError("[SaveSystem] LoadGame failed: " + e.Message);
            return new GameSave();
        }
    }

    public static bool GameSaveExists() => File.Exists(gameSavePath);
    public static void DeleteGameSave() { if (File.Exists(gameSavePath)) File.Delete(gameSavePath); }

    // ---- Account settings ----
    public static void SaveAccountSettings(AccountSettingsSave data)
    {
        try
        {
            if (!Directory.Exists(SavesFolder))
                Directory.CreateDirectory(SavesFolder);

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(accountSettingsPath, json);
            Debug.Log("[SaveSystem] Account settings saved to: " + accountSettingsPath);
        }
        catch (Exception e)
        {
            Debug.LogError("[SaveSystem] SaveAccountSettings failed: " + e.Message);
        }
    }

    public static AccountSettingsSave LoadAccountSettings()
    {
        try
        {
            if (!File.Exists(accountSettingsPath))
            {
                Debug.Log("[SaveSystem] No account settings found. Creating default.");
                var defaultSettings = new AccountSettingsSave();
                SaveAccountSettings(defaultSettings);
                return defaultSettings;
            }

            string json = File.ReadAllText(accountSettingsPath);
            var settings = JsonUtility.FromJson<AccountSettingsSave>(json);
            Debug.Log("[SaveSystem] Account settings loaded from: " + accountSettingsPath);
            return settings;
        }
        catch (Exception e)
        {
            Debug.LogError("[SaveSystem] LoadAccountSettings failed: " + e.Message);
            return new AccountSettingsSave();
        }
    }
}
