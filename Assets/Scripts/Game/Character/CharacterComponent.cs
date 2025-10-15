using UnityEngine;

// демонстрация как привязать Character к GameSave.currentGameCharacter
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterComponent : MonoBehaviour, IGameSaveable
{
    // локальные runtime-поля (видимые в инспекторе для теста)
    [Header("Runtime stats (editable)")]
    public string characterName = "Безымянный";
    public string characterClass = "Воин";
    public int level = 1;
    public CharacterStats stats = new CharacterStats();

    public void LoadFromGameSave(GameSave save)
    {
        if (save == null || save.currentGameCharacter == null) return;

        var c = save.currentGameCharacter;
        characterName = c.name;
        characterClass = c.characterClass;
        level = c.level;
        stats = c.stats;

        // если позиция задана — переместим объект
        transform.position = c.position.ToVector3();
    }

    //по идее не работает
    public void SaveToGameSave(GameSave save)
    {
        if (save == null) return;

        var c = save.currentGameCharacter;
        c.name = characterName;
        c.characterClass = characterClass;
        c.level = level;
        c.stats = stats;
        c.position.FromVector3(transform.position);
    }
}
