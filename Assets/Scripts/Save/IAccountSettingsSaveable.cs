using UnityEngine;

public interface IAccountSettingsSaveable
{
    void LoadFromAccountSettings(AccountSettingsSave settings);
    void SaveToAccountSettings(AccountSettingsSave settings);
}
