using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OptionsMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject optionsPanel;
    public TMP_Dropdown resolutionDropdown;

    public Slider masterVolumeSlider;

    private AccountSettingsSave settings;

    private void Start()
    {
        // Загружаем текущие настройки
        settings = AccountSettingsManager.Instance.CurrentSettings;

        // Заполняем Dropdown примерами разрешений
        resolutionDropdown.ClearOptions();
        List<string> resolutions = new List<string> { "1920x1080", "1600x900", "1280x720" };
        resolutionDropdown.AddOptions(resolutions);

        // Устанавливаем текущее значение
        resolutionDropdown.value = resolutions.IndexOf(settings.graphics.resolution);
        masterVolumeSlider.value = settings.audio.masterVolume;

        // Подписка на изменения
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        masterVolumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // Скрыть панель по умолчанию
        optionsPanel.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    private void OnResolutionChanged(int index)
    {
        string selected = resolutionDropdown.options[index].text;
        settings.graphics.resolution = selected;
        AccountSettingsManager.Instance.SaveSettings();
        Debug.Log("Resolution changed to " + selected);
    }

    private void OnVolumeChanged(float value)
    {
        settings.audio.masterVolume = value;
        AccountSettingsManager.Instance.SaveSettings();
        Debug.Log("Master volume changed to " + value);
    }
}
