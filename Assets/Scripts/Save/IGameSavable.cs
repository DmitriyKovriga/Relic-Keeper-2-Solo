using UnityEngine;

public interface IGameSaveable
{
    void LoadFromGameSave(GameSave save);
    void SaveToGameSave(GameSave save);
}
