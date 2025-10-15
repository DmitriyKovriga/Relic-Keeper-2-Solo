using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AccountSettingsManager : MonoBehaviour
{
    public static AccountSettingsManager Instance { get; private set; }
    public AccountSettingsSave CurrentSettings { get; private set; }

    private List<IAccountSettingsSaveable> settingsSaveables = new List<IAccountSettingsSaveable>();

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); return; }

        CurrentSettings = SaveSystem.LoadAccountSettings();
        RefreshSaveables();
        foreach (var s in settingsSaveables) s.LoadFromAccountSettings(CurrentSettings);
    }

    public void RefreshSaveables()
    {
        settingsSaveables = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IAccountSettingsSaveable>()
            .ToList();
    }

    public void SaveSettings()
    {
        foreach (var s in settingsSaveables) s.SaveToAccountSettings(CurrentSettings);
        SaveSystem.SaveAccountSettings(CurrentSettings);
    }

    public void LoadSettings()
    {
        CurrentSettings = SaveSystem.LoadAccountSettings();
        RefreshSaveables();
        foreach (var s in settingsSaveables) s.LoadFromAccountSettings(CurrentSettings);
    }
}
