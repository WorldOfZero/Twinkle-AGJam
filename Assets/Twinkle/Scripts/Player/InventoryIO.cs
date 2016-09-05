using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class InventoryIO {

    private const string prefKey = "PlayerInventory";

    public static void Save(List<string> inventory)
    {
        
        var jsonInventory = JsonUtility.ToJson(new InventoryStorage() { inventory = inventory });
        PlayerPrefs.SetString(prefKey, jsonInventory);
        PlayerPrefs.Save();
    }

    public static List<string> Load()
    {
        var jsonInventory = PlayerPrefs.GetString(prefKey);
        var inventory = JsonUtility.FromJson<InventoryStorage>(jsonInventory);
        if (inventory == null)
        {
            return LoadStartingInventory();
        }
        else return inventory.inventory;
    }

    private static List<string> LoadStartingInventory(int initialNumber = 10)
    {
        //Starting inventory is a random set of X sounds.
        var cache = GameObject.FindObjectOfType<SoundModelCache>();
        return cache.soundModels.Values.
            OrderBy((sound) => UnityEngine.Random.value).
            Take(initialNumber).
            Select((soundModel) => soundModel.guid).
            ToList();
    }

    [Serializable]
    public class InventoryStorage
    {
        public List<string> inventory;
    }
}
