using System;
using UnityEngine;

[Serializable]
public class AccountSettingsSave
{
    public GraphicsSettings graphics = new GraphicsSettings();
    public AudioSettings audio = new AudioSettings();
    public GameplaySettings gameplay = new GameplaySettings();
}

[Serializable]
public class GraphicsSettings
{
    public string resolution = "1920x1080";
    public bool fullscreen = true;
    public bool vSync = true;
    public string quality = "High";
}

[Serializable]
public class AudioSettings
{
    public float masterVolume = 1f;
    public float musicVolume = 0.8f;
    public float sfxVolume = 0.8f;
}

[Serializable]
public class GameplaySettings
{
    public string language = "ru";
    public bool showHints = true;
}
