using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameSave
{
    public CurrentGameCharacter currentGameCharacter = new CurrentGameCharacter();
    public PlayerStash playerStash = new PlayerStash();
    public Inventory inventory = new Inventory();
    public WorldData worldData = new WorldData();
}

[Serializable]
public class CurrentGameCharacter
{
    public string name = "Безымянный";
    public string characterClass = "Воин";
    public int level = 1;
    public float experience = 0f;
    public CharacterStats stats = new CharacterStats();
    public Equipment equipment = new Equipment();
    public SerializableVector3 position = new SerializableVector3();
}

[Serializable]
public class CharacterStats
{
    public float health = 100f;
    public float strength = 10f;
    public float agility = 8f;
    public float vitality = 12f;
}

[Serializable]
public class Equipment
{
    public string weaponId = "";
    public string armorId = "";
    // тут в будущем можно хранить слоты, модификаторы и т.д.
}

[Serializable]
public class PlayerStash
{
    public int gold = 0;
    public List<string> storedItems = new List<string>();
}

[Serializable]
public class Inventory
{
    public List<InventorySlot> slots = new List<InventorySlot>();
}

[Serializable]
public class InventorySlot
{
    public string itemId;
    public int count;
}

[Serializable]
public class WorldData
{
    public int currentLevel = 1;
    public List<string> discoveredRooms = new List<string>();
    public bool bossDefeated = false;
}

// простой сериализуемый Vector3-вайпер (на всякий случай)
[Serializable]
public class SerializableVector3
{
    public float x, y, z;
    public SerializableVector3() { x = y = z = 0f; }
    public SerializableVector3(float rx, float ry, float rz) { x = rx; y = ry; z = rz; }
    public Vector3 ToVector3() => new Vector3(x, y, z);
    public void FromVector3(Vector3 v) { x = v.x; y = v.y; z = v.z; }
}
