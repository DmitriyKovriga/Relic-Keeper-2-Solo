using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager Instance { get; private set; }

    public GameSave CurrentGameSave { get; private set; }

    private List<IGameSaveable> saveables = new List<IGameSaveable>();

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); return; }

        // загрузить сохранение с диска
        CurrentGameSave = SaveSystem.LoadGame();

        // найти все объекты в сцене, которые реализуют IGameSaveable
        RefreshSaveables();
        // попросить их загрузить данные из CurrentGameSave
        foreach (var s in saveables) s.LoadFromGameSave(CurrentGameSave);
    }

    // вызвать, если сцена сменилась и нужно обновить список
    public void RefreshSaveables()
    {
        saveables = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IGameSaveable>()
            .ToList();
    }

    public void SaveGame()
    {
        // попросить все saveables записать свои данные в CurrentGameSave
        foreach (var s in saveables) s.SaveToGameSave(CurrentGameSave);

        SaveSystem.SaveGame(CurrentGameSave);
    }

    public void LoadGame()
    {
        CurrentGameSave = SaveSystem.LoadGame();
        RefreshSaveables();
        foreach (var s in saveables) s.LoadFromGameSave(CurrentGameSave);
    }

    public void NewGame()
    {
        CurrentGameSave = new GameSave();
        SaveSystem.SaveGame(CurrentGameSave);
        RefreshSaveables();
        foreach (var s in saveables) s.LoadFromGameSave(CurrentGameSave);
    }

    public void DeleteSave()
    {
        SaveSystem.DeleteGameSave();
        CurrentGameSave = new GameSave();
        RefreshSaveables();
        foreach (var s in saveables) s.LoadFromGameSave(CurrentGameSave);
    }
}
